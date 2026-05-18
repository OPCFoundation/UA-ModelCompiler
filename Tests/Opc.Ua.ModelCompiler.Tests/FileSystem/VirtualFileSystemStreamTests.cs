/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

namespace ModelCompiler
{
    /// <summary>
    /// Tests for VirtualFileSystem stream operations and edge cases
    /// </summary>
    public class VirtualFileSystemStreamTests
    {
        [Fact]
        public void Stream_SeekOperations_WorkCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "seektest.txt";
            var content = "0123456789ABCDEF"u8.ToArray();
            vfs.Add(filePath, content);

            // Act & Assert
            using var stream = vfs.OpenRead(filePath);

            // Test seeking from beginning
            var position = stream.Seek(5, SeekOrigin.Begin);
            Assert.Equal(5, position);

            var buffer = new byte[1];
            stream.ReadExactly(buffer, 0, 1);
            Assert.Equal((byte)'5', buffer[0]);

            // Test seeking from current position
            position = stream.Seek(3, SeekOrigin.Current);
            Assert.Equal(9, position);

            stream.ReadExactly(buffer, 0, 1);
            Assert.Equal((byte)'9', buffer[0]);

            // Test seeking from end
            position = stream.Seek(-2, SeekOrigin.End);
            Assert.Equal(content.Length - 2, position);

            stream.ReadExactly(buffer, 0, 1);
            Assert.Equal((byte)'E', buffer[0]);
        }

        [Fact]
        public void WriteStream_SeekOperations_ThrowWhenNotSupported()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "writetest.txt";
            vfs.Add(filePath, []);

            // Act & Assert
            using var stream = vfs.OpenRead(filePath);

            // Test set length throws exception
            var lengthException = Assert.Throws<InvalidOperationException>(() => stream.SetLength(100));
            Assert.Contains("Cannot set a length when opened in read mode", lengthException.Message);

            stream.SetLength(stream.Length); // Should not throw
        }

        [Fact]
        public void Stream_ReadBeyondLength_ReturnsCorrectAmount()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "shortfile.txt";
            var content = "Hello"u8.ToArray(); // 5 bytes
            vfs.Add(filePath, content);

            // Act
            using var stream = vfs.OpenRead(filePath);

            // Try to read more than available
            var buffer = new byte[10];
            var bytesRead = stream.Read(buffer, 0, 10);

            // Assert
            Assert.Equal(5, bytesRead); // Only 5 bytes available
            Assert.Equal(content, buffer.Take(5));
            Assert.Equal(5, stream.Position);
        }

        [Fact]
        public void Stream_ReadAtExactLength_ReturnsZero()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "exactlength.txt";
            var content = "Hello"u8.ToArray();
            vfs.Add(filePath, content);

            // Act
            using var stream = vfs.OpenRead(filePath);

            // Read all content first
            var buffer1 = new byte[5];
            stream.ReadExactly(buffer1, 0, 5);

            // Try to read more at end of file
            var buffer2 = new byte[5];
            var bytesRead = stream.Read(buffer2, 0, 5);

            // Assert
            Assert.Equal(0, bytesRead);
            Assert.Equal(5, stream.Position);
        }

        [Fact]
        public void Stream_MultipleWrites_UpdatePositionCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "multiwrite.txt";
            var part1 = "Hello "u8.ToArray();
            var part2 = "World"u8.ToArray();

            // Act
            using (var stream = vfs.OpenWrite(filePath))
            {
                stream.Write(part1, 0, part1.Length);
                Assert.Equal(part1.Length, stream.Position);

                stream.Write(part2, 0, part2.Length);
                Assert.Equal(part1.Length + part2.Length, stream.Position);

                stream.Flush();
            }

            // Assert
            var expectedContent = "Hello World"u8.ToArray();
            Assert.Equal(expectedContent, vfs.Get(filePath));
        }

        [Fact]
        public void Stream_Properties_ReturnCorrectValues()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "properties.txt";
            var content = "Hello World"u8.ToArray();
            vfs.Add(filePath, content);

            // Act & Assert - Read stream
            using (var readStream = vfs.OpenRead(filePath))
            {
                Assert.True(readStream.CanRead);
                Assert.False(readStream.CanWrite);
                Assert.True(readStream.CanSeek);
                Assert.Equal(content.Length, readStream.Length);
                Assert.Equal(0, readStream.Position);
            }

            // Act & Assert - Write stream
            using var writeStream = vfs.OpenWrite(filePath);

            Assert.False(writeStream.CanRead);
            Assert.True(writeStream.CanWrite);
            Assert.True(writeStream.CanSeek);
            Assert.Equal(0, writeStream.Position);
        }

        [Fact]
        public void Stream_Disposal_UpdatesFileLengthCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "disposaltest.txt";
            var content = "Hello World"u8.ToArray();

            // Act - Write content and dispose stream
            using (var stream = vfs.OpenWrite(filePath))
            {
                stream.Write(content, 0, content.Length);
                // Stream disposal should update the file length
            }

            // Assert - File should have correct content
            Assert.True(vfs.Exists(filePath));

            using var readStream = vfs.OpenRead(filePath);
            Assert.Equal(content.Length, readStream.Length);

            var buffer = new byte[content.Length];
            var bytesRead = readStream.Read(buffer, 0, buffer.Length);
            Assert.Equal(content.Length, bytesRead);
            Assert.Equal(content, buffer);
        }

        [Fact]
        public void WriteAndReadBack_SingleFile_MaintainsConsistency()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "consistency.txt";
            var originalContent = "This is the original content that should remain consistent"u8.ToArray();

            // Act & Assert - Write and read back multiple times
            for (int i = 0; i < 10; i++)
            {
                // Write content
                using (var writeStream = vfs.OpenWrite(filePath))
                {
                    writeStream.Write(originalContent, 0, originalContent.Length);
                }

                // Read content back and verify
                using (var readStream = vfs.OpenRead(filePath))
                {
                    var buffer = new byte[originalContent.Length];
                    var bytesRead = readStream.Read(buffer, 0, buffer.Length);

                    Assert.Equal(originalContent.Length, bytesRead);
                    Assert.Equal(originalContent, buffer);
                }

                // Also verify with Get method
                var retrievedContent = vfs.Get(filePath);
                Assert.Equal(originalContent, retrievedContent);
            }
        }

        [Fact]
        public void WriteAndReadBack_MultipleFiles_MaintainIndividualConsistency()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var testData = new Dictionary<string, byte[]>
            {
                ["file1.txt"] = "Content for file 1"u8.ToArray(),
                ["file2.txt"] = "Different content for file 2 with more text"u8.ToArray(),
                ["file3.txt"] = "Short"u8.ToArray(),
                ["file4.txt"] = [],
                ["file5.txt"] = new byte[1000] // Large content
            };

            // Initialize large content with pattern
            for (int i = 0; i < testData["file5.txt"].Length; i++)
            {
                testData["file5.txt"][i] = (byte)(i % 256);
            }

            // Act & Assert - Write all files, then read them back multiple times
            foreach (var kvp in testData)
            {
                using var writeStream = vfs.OpenWrite(kvp.Key);
                writeStream.Write(kvp.Value, 0, kvp.Value.Length);
            }

            // Perform multiple read cycles to ensure consistency
            for (int cycle = 0; cycle < 5; cycle++)
            {
                foreach (var kvp in testData)
                {
                    // Test with stream reading
                    using (var readStream = vfs.OpenRead(kvp.Key))
                    {
                        var buffer = new byte[kvp.Value.Length];
                        var bytesRead = readStream.Read(buffer, 0, buffer.Length);

                        Assert.Equal(kvp.Value.Length, bytesRead);
                        Assert.Equal(kvp.Value, buffer);
                    }

                    // Test with direct Get method
                    var retrievedContent = vfs.Get(kvp.Key);
                    Assert.Equal(kvp.Value, retrievedContent);
                }
            }
        }

        [Fact]
        public void WriteAndReadBack_OverwriteContent_MaintainsNewContent()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "overwrite.txt";
            var contents = new []
            {
                "First version of content"u8.ToArray(),
                "Second version with different length and content"u8.ToArray(),
                "Third"u8.ToArray(),
                [],
                "Final version after empty"u8.ToArray()
            };

            // Act & Assert - Write each version and verify it can be read back correctly
            for (int i = 0; i < contents.Length; i++)
            {
                var currentContent = contents[i];

                // Write new content
                using (var writeStream = vfs.OpenWrite(filePath))
                {
                    writeStream.Write(currentContent, 0, currentContent.Length);
                }

                // Read back and verify multiple times to ensure consistency
                for (int readCycle = 0; readCycle < 3; readCycle++)
                {
                    using (var readStream = vfs.OpenRead(filePath))
                    {
                        Assert.Equal(currentContent.Length, readStream.Length);

                        var buffer = new byte[Math.Max(currentContent.Length, 1)]; // Ensure buffer is at least size 1
                        var bytesRead = readStream.Read(buffer, 0, currentContent.Length);

                        Assert.Equal(currentContent.Length, bytesRead);

                        if (currentContent.Length > 0)
                        {
                            var result = buffer.Take(currentContent.Length).ToArray();
                            Assert.Equal(currentContent, result);
                        }
                    }

                    // Also verify with Get method
                    var retrievedContent = vfs.Get(filePath);
                    Assert.Equal(currentContent, retrievedContent);
                }
            }
        }

        [Fact]
        public void WriteAndReadBack_PartialWrites_BuildsContentCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "partial.txt";
            var parts = new[]
            {
                "Hello"u8.ToArray(),
                " "u8.ToArray(),
                "World"u8.ToArray(),
                "!"u8.ToArray(),
                " This is a longer ending."u8.ToArray()
            };
            var expectedFinalContent = parts.SelectMany(p => p).ToArray();

            // Act - Write content in parts
            using (var writeStream = vfs.OpenWrite(filePath))
            {
                foreach (var part in parts)
                {
                    writeStream.Write(part, 0, part.Length);
                }
            }

            // Assert - Read back and verify multiple times
            for (int readCycle = 0; readCycle < 5; readCycle++)
            {
                using (var readStream = vfs.OpenRead(filePath))
                {
                    Assert.Equal(expectedFinalContent.Length, readStream.Length);

                    var buffer = new byte[expectedFinalContent.Length];
                    var bytesRead = readStream.Read(buffer, 0, buffer.Length);

                    Assert.Equal(expectedFinalContent.Length, bytesRead);
                    Assert.Equal(expectedFinalContent, buffer);
                }

                // Also verify with Get method
                var retrievedContent = vfs.Get(filePath);
                Assert.Equal(expectedFinalContent, retrievedContent);
            }
        }

        [Fact]
        public void WriteAndReadBack_RandomContent_MaintainsIntegrity()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "random.dat";
            var random = new Random(12345); // Fixed seed for reproducible test
            var sizes = new[] { 0, 1, 10, 100, 1000, 10000 };

            foreach (var size in sizes)
            {
                // Generate random content
                var content = new byte[size];
                random.NextBytes(content);

                // Act - Write random content
                using (var writeStream = vfs.OpenWrite(filePath))
                {
                    writeStream.Write(content, 0, content.Length);
                }

                // Assert - Read back and verify consistency multiple times
                for (int readAttempt = 0; readAttempt < 3; readAttempt++)
                {
                    using (var readStream = vfs.OpenRead(filePath))
                    {
                        Assert.Equal(content.Length, readStream.Length);

                        if (content.Length > 0)
                        {
                            var buffer = new byte[content.Length];
                            var bytesRead = readStream.Read(buffer, 0, buffer.Length);

                            Assert.Equal(content.Length, bytesRead);
                            Assert.Equal(content, buffer);
                        }
                    }

                    // Also verify with Get method
                    var retrievedContent = vfs.Get(filePath);
                    Assert.Equal(content, retrievedContent);
                }
            }
        }

        [Fact]
        public async Task WriteAndReadBack_ConcurrentOperations_MaintainConsistency_Async()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            const int fileCount = 10;
            const int cycleCount = 5;
            var contentMap = new Dictionary<string, byte[]>();

            // Generate unique content for each file
            for (int i = 0; i < fileCount; i++)
            {
                var filePath = $"concurrent{i}.txt";
                var content = System.Text.Encoding.UTF8.GetBytes($"Content for file {i} - {DateTime.UtcNow.Ticks}");
                contentMap[filePath] = content;
            }

            // Act - Perform concurrent write/read operations
            var tasks = new List<Task>();

            for (int cycle = 0; cycle < cycleCount; cycle++)
            {
                foreach (var kvp in contentMap)
                {
                    var filePath = kvp.Key;
                    var expectedContent = kvp.Value;

                    tasks.Add(Task.Run(() =>
                    {
                        // Write content
                        using (var writeStream = vfs.OpenWrite(filePath))
                        {
                            writeStream.Write(expectedContent, 0, expectedContent.Length);
                        }

                        // Immediately read back and verify
                        Thread.Sleep(1); // Small delay to allow for race conditions

                        using (var readStream = vfs.OpenRead(filePath))
                        {
                            var buffer = new byte[expectedContent.Length];
                            var bytesRead = readStream.Read(buffer, 0, buffer.Length);

                            if (bytesRead != expectedContent.Length || !buffer.SequenceEqual(expectedContent))
                            {
                                throw new InvalidOperationException($"Content mismatch for {filePath}");
                            }
                        }

                        // Also verify with Get method
                        var retrievedContent = vfs.Get(filePath);
                        if (!retrievedContent.SequenceEqual(expectedContent))
                        {
                            throw new InvalidOperationException($"Get method content mismatch for {filePath}");
                        }
                    }));
                }
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            // Final verification - ensure all files have correct content
            foreach (var kvp in contentMap)
            {
                Assert.True(vfs.Exists(kvp.Key), $"File {kvp.Key} should exist");
                Assert.Equal(kvp.Value, vfs.Get(kvp.Key));
            }
        }
    }
}