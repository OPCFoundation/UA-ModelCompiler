/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community License ("RCL") Version 1.00
 *
 * Unless explicitly acquired and licensed from Licensor under another
 * license, the contents of this file are subject to the Reciprocal
 * Community License ("RCL") Version 1.00, or subsequent versions
 * as allowed by the RCL, and You may not copy or use this file in either
 * source code or executable form, except in compliance with the terms and
 * conditions of the RCL.
 *
 * All software distributed under the RCL is provided strictly on an
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCL for specific
 * language governing rights and limitations under the RCL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCL/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// Manages the server side of a UA TCP channel.
    /// </summary>
    public partial class TcpChannel
    {
        /// <summary>
        /// Return the plaintext block size for RSA OAEP encryption.
        /// </summary>
        protected static int Rsa_GetPlainTextBlockSize(X509Certificate2 encryptingCertificate, bool useOaep)
        {
            RSACryptoServiceProvider rsa = encryptingCertificate.PublicKey.Key as RSACryptoServiceProvider;

            if (rsa != null)
            {
                if (useOaep)
                {
                    return rsa.KeySize/8 - 42;
                }
                else
                {
                    return rsa.KeySize/8 - 11;
                }
            }

            return -1;
        }

        /// <summary>
        /// Return the ciphertext block size for RSA OAEP encryption.
        /// </summary>
        protected static int Rsa_GetCipherTextBlockSize(X509Certificate2 encryptingCertificate, bool useOaep)
        {
            RSACryptoServiceProvider rsa = encryptingCertificate.PublicKey.Key as RSACryptoServiceProvider;

            if (rsa != null)
            {
                return rsa.KeySize/8;
            }

            return -1;
        }

        /// <summary>
        /// Returns the length of a RSA PKCS#1 v1.5 signature of a SHA1 digest.
        /// </summary>
        private static int RsaPkcs15Sha1_GetSignatureLength(X509Certificate2 signingCertificate)
        {
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PublicKey.Key;

            if (rsa == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No public key for certificate.");
            }

            return rsa.KeySize/8;
        }

        /// <summary>
        /// Creates an RSA PKCS#1 v1.5 signature of a SHA1 for the stream.
        /// </summary>
        private static byte[] RsaPkcs15Sha1_Sign(
            ArraySegment<byte> dataToSign,
            X509Certificate2   signingCertificate)
        {
            // extract the private key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PrivateKey;

            if (rsa == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No private key for certificate.");
            }

            // compute the hash of message.
            MemoryStream istrm = new MemoryStream(dataToSign.Array, dataToSign.Offset, dataToSign.Count, false);

            SHA1 hash = new SHA1Managed();
            byte[] digest = hash.ComputeHash(istrm);

            istrm.Close();

            // create the signature.
            return rsa.SignHash(digest, "SHA1");
        }

        /// <summary>
        /// Verifies an RSA PKCS#1 v1.5 signature of a SHA1 for the stream.
        /// </summary>
        private static bool RsaPkcs15Sha1_Verify(
            ArraySegment<byte> dataToVerify,
            byte[]             signature,
            X509Certificate2   signingCertificate)
        {
            // extract the private key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PublicKey.Key;

            if (rsa == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No public key for certificate.");
            }

            // compute the hash of message.
            MemoryStream istrm = new MemoryStream(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, false);

            SHA1 hash = new SHA1Managed();
            byte[] digest = hash.ComputeHash(istrm);

            istrm.Close();

            // verify signature.
            if (!rsa.VerifyHash(digest, "SHA1", signature))
            {
                string messageType = new UTF8Encoding().GetString(dataToVerify.Array, dataToVerify.Offset, 4);
                int messageLength = BitConverter.ToInt32(dataToVerify.Array, dataToVerify.Offset+4);
                string expectedDigest = Utils.ToHexString(digest);
                string actualSignature = Utils.ToHexString(signature);

                Utils.Trace(
                    "Could not validate signature.\r\nCertificate={0}, MessageType={1}, Length={2}\r\nDigest={3}\r\nActualSignature={4}",
                    signingCertificate.Subject,
                    messageType,
                    messageLength,
                    expectedDigest,
                    actualSignature);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Encrypts the message using RSA PKCS#1 v1.5 encryption.
        /// </summary>
        private ArraySegment<byte> Rsa_Encrypt(
            ArraySegment<byte> dataToEncrypt,
            ArraySegment<byte> headerToCopy,
            X509Certificate2   encryptingCertificate,
            bool               useOaep)
        {
            // get the encrypting key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)encryptingCertificate.PublicKey.Key;

            if (rsa == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No public key for certificate.");
            }

            int inputBlockSize  = Rsa_GetPlainTextBlockSize(encryptingCertificate, useOaep);
            int outputBlockSize = rsa.KeySize/8;

            // verify the input data is the correct block size.
            if (dataToEncrypt.Count % inputBlockSize != 0)
            {
                Utils.Trace("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", dataToEncrypt.Count, inputBlockSize);
            }

            byte[] encryptedBuffer = BufferManager.TakeBuffer(SendBufferSize, "Rsa_Encrypt");
            Array.Copy(headerToCopy.Array, headerToCopy.Offset, encryptedBuffer, 0, headerToCopy.Count);

            MemoryStream ostrm = new MemoryStream(
                encryptedBuffer,
                headerToCopy.Count,
                encryptedBuffer.Length - headerToCopy.Count);

            // encrypt body.
            byte[] input = new byte[inputBlockSize];

            for (int ii = dataToEncrypt.Offset; ii < dataToEncrypt.Offset + dataToEncrypt.Count; ii += inputBlockSize)
            {
                Array.Copy(dataToEncrypt.Array, ii, input, 0, input.Length);
                byte[] cipherText = rsa.Encrypt(input, useOaep);
                ostrm.Write(cipherText, 0, cipherText.Length);
            }

            ostrm.Close();

            // return buffer
            return new ArraySegment<byte>(encryptedBuffer, 0, (dataToEncrypt.Count/inputBlockSize)*outputBlockSize + headerToCopy.Count);
        }

        /// <summary>
        /// Encrypts the message using RSA OAEP encryption.
        /// </summary>
        private ArraySegment<byte> Rsa_Decrypt(
            ArraySegment<byte> dataToDecrypt,
            ArraySegment<byte> headerToCopy,
            X509Certificate2   encryptingCertificate,
            bool               useOaep)
        {
            // get the encrypting key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)encryptingCertificate.PrivateKey;

            if (rsa == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No private key for certificate.");
            }

            int inputBlockSize  = rsa.KeySize/8;
            int outputBlockSize = Rsa_GetPlainTextBlockSize(encryptingCertificate, useOaep);

            // verify the input data is the correct block size.
            if (dataToDecrypt.Count % inputBlockSize != 0)
            {
                Utils.Trace("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", dataToDecrypt.Count, inputBlockSize);
            }

            byte[] decryptedBuffer = BufferManager.TakeBuffer(SendBufferSize, "Rsa_Decrypt");
            Array.Copy(headerToCopy.Array, headerToCopy.Offset, decryptedBuffer, 0, headerToCopy.Count);

            MemoryStream ostrm = new MemoryStream(
                decryptedBuffer,
                headerToCopy.Count,
                decryptedBuffer.Length - headerToCopy.Count);

            // decrypt body.
            byte[] input = new byte[inputBlockSize];

            for (int ii = dataToDecrypt.Offset; ii < dataToDecrypt.Offset + dataToDecrypt.Count; ii += inputBlockSize)
            {
                Array.Copy(dataToDecrypt.Array, ii, input, 0, input.Length);
                byte[] plainText = rsa.Decrypt(input, useOaep);
                ostrm.Write(plainText, 0, plainText.Length);
            }

            ostrm.Close();

            // return buffers.
            return new ArraySegment<byte>(decryptedBuffer, 0, (dataToDecrypt.Count/inputBlockSize)*outputBlockSize + headerToCopy.Count);
        }
    }
}
