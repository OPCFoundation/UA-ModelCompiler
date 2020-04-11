@echo off
setlocal

echo Processing NodeSet Schema
xsd /classes /n:Opc.Ua.Schema.Binary OPCBinarySchema.xsd

echo #pragma warning disable 1591 > temp.txt
type OPCBinarySchema.cs >> temp.txt
type temp.txt > OPCBinarySchema.cs
