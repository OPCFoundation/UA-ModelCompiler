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
    /// Tests for VirtualFileSystem error conditions and edge cases
    /// </summary>
    public class VirtualFileSystemEdgeCaseTests
    {
        [Fact]
        public void FilePath_WithSpecialCharacters_WorksCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePaths = new[]
            {
                "file with spaces.txt",
                "file-with-dashes.txt",
                "file_with_underscores.txt",
                "file.with.dots.txt",
                "file@with#symbols$.txt"
            };
            var content = "test content"u8.ToArray();

            // Act & Assert
            foreach (var filePath in filePaths)
            {
                vfs.Add(filePath, content);
                Assert.True(vfs.Exists(filePath));
                Assert.Equal(content, vfs.Get(filePath));
            }

            Assert.Equal(filePaths.Length, vfs.Files.Count());
        }

        [Fact]
        public void FilePath_VeryLong_WorksCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var longPath = "very/long/path/with/many/nested/directories/and/a/very/long/filename/that/exceeds/normal/expectations/test.txt";
            var content = "test content"u8.ToArray();

            // Act
            vfs.Add(longPath, content);

            // Assert
            Assert.True(vfs.Exists(longPath));
            Assert.Equal(content, vfs.Get(longPath));
        }

        [Fact]
        public void Add_EmptyPath_HandlesGracefully()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var content = "test content"u8.ToArray();

            // Act & Assert - Empty string
            vfs.Add("", content);
            Assert.True(vfs.Exists(""));
            Assert.Equal(content, vfs.Get(""));
        }

        [Fact]
        public void Add_NullContent_ThrowsException()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "test.txt";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => vfs.Add(filePath, null!));
        }

        [Fact]
        public void ManyFiles_WorksCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            const int fileCount = 1000;
            var content = "test content"u8.ToArray();

            // Act
            for (int i = 0; i < fileCount; i++)
            {
                vfs.Add($"file{i:D4}.txt", content);
            }

            // Assert
            Assert.Equal(fileCount, vfs.Files.Count());

            // Verify a few random files
            var random = new Random(42); // Fixed seed for reproducible tests
            for (int i = 0; i < 10; i++)
            {
                var index = random.Next(fileCount);
                var filePath = $"file{index:D4}.txt";

                Assert.True(vfs.Exists(filePath));
                Assert.Equal(content, vfs.Get(filePath));
            }
        }

        [Fact]
        public void FileOperations_UnicodePaths_WorkCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var unicodePaths = new[]
            {
                "файл.txt", // Russian
                "文件.txt", // Chinese
                "ファイル.txt", // Japanese
                "파일.txt", // Korean
                "αρχείο.txt", // Greek
                "файл🎉.txt" // With emoji
            };
            var content = "Unicode test content"u8.ToArray();

            // Act & Assert
            foreach (var filePath in unicodePaths)
            {
                vfs.Add(filePath, content);
                Assert.True(vfs.Exists(filePath));
                Assert.Equal(content, vfs.Get(filePath));
            }
        }

        [Fact]
        public void MemoryPressure_LargeFiles_HandledGracefully()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();

            // Act - Create several moderately large files
            for (int i = 0; i < 5; i++)
            {
                var filePath = $"large{i}.dat";
                var largeContent = new byte[1024 * 1024]; // 1MB each
                Random.Shared.NextBytes(largeContent);

                vfs.Add(filePath, largeContent);
            }

            // Assert - All files should be accessible
            Assert.Equal(5, vfs.Files.Count());

            for (int i = 0; i < 5; i++)
            {
                var filePath = $"large{i}.dat";
                Assert.True(vfs.Exists(filePath));

                var content = vfs.Get(filePath);
                Assert.Equal(1024 * 1024, content.Length);
            }
        }

        [Fact]
        public void RapidAddDelete_WorksCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "rapidtest.txt";
            var content = "test content"u8.ToArray();

            // Act & Assert - Rapid add/delete cycles
            for (int i = 0; i < 100; i++)
            {
                vfs.Add(filePath, content);
                Assert.True(vfs.Exists(filePath));

                vfs.Delete(filePath);
                Assert.False(vfs.Exists(filePath));
            }

            Assert.Empty(vfs.Files);
        }

        [Fact]
        public void FileOperations_AfterPartialDisposal_StillWork()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath1 = "file1.txt";
            var filePath2 = "file2.txt";
            var content = "test content"u8.ToArray();

            vfs.Add(filePath1, content);
            vfs.Add(filePath2, content);

            // Act - Delete one file
            vfs.Delete(filePath1);

            // Assert - Other file should still work
            Assert.False(vfs.Exists(filePath1));
            Assert.True(vfs.Exists(filePath2));
            Assert.Equal(content, vfs.Get(filePath2));
            Assert.Single(vfs.Files);
        }

        [Fact]
        public void StreamOperations_ZeroLengthBuffers_WorkCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "zerobuffer.txt";
            var content = "test content"u8.ToArray();
            vfs.Add(filePath, content);

            // Act & Assert - Reading with zero-length buffer
            using (var stream = vfs.OpenRead(filePath))
            {
                var buffer = Array.Empty<byte>();
                var bytesRead = stream.Read(buffer, 0, 0);
                Assert.Equal(0, bytesRead);
                Assert.Equal(0, stream.Position);
            }

            // Act & Assert - Writing with zero-length buffer
            using (var stream = vfs.OpenWrite("empty.txt"))
            {
                var buffer = Array.Empty<byte>();
                stream.Write(buffer, 0, 0);
                Assert.Equal(0, stream.Position);
            }
        }

        [Fact]
        public void FilePaths_WithDirectorySeparators_WorkCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePaths = new[]
            {
                "folder/file.txt",
                "folder\\file2.txt",
                "deep/nested/folder/file.txt",
                "deep\\nested\\folder\\file2.txt"
            };
            var content = "nested content"u8.ToArray();

            // Act & Assert
            foreach (var filePath in filePaths)
            {
                vfs.Add(filePath, content);
                Assert.True(vfs.Exists(filePath));
                Assert.Equal(content, vfs.Get(filePath));
            }

            // Different separators should be treated as different paths
            Assert.Equal(filePaths.Length, vfs.Files.Count());
        }

        [Fact]
        public void GetLastWriteTime_NonExistentPhysicalFile_FallsBackGracefully()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var nonExistentPath = "this/file/does/not/exist/anywhere.txt";

            // Act & Assert - Should not throw, but return default time from FileInfo
            var result = vfs.GetLastWriteTime(nonExistentPath);

            // The result will be whatever FileInfo returns for non-existent files
            // This is implementation detail, but should not throw
            Assert.IsType<DateTime>(result);
        }

        [Fact]
        public void StreamPosition_PartialReads_WorksCorrectly()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "partialread.txt";
            var content = "0123456789"u8.ToArray(); // 10 bytes
            vfs.Add(filePath, content);

            // Act & Assert
            using var stream = vfs.OpenRead(filePath);
            var buffer = new byte[15]; // Larger than content

            // First read - should read all available
            var firstRead = stream.Read(buffer, 0, 15);
            Assert.Equal(10, firstRead);
            Assert.Equal(10, stream.Position);

            // Second read - should return 0 (end of file)
            var secondRead = stream.Read(buffer, 0, 15);
            Assert.Equal(0, secondRead);
            Assert.Equal(10, stream.Position);
        }

        [Fact]
        public void Add_OverwriteExistingFile_UpdatesContent()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var filePath = "overwrite.txt";
            var originalContent = "Original content"u8.ToArray();
            var newContent = "New content that is different"u8.ToArray();

            // Act
            vfs.Add(filePath, originalContent);
            Assert.Equal(originalContent, vfs.Get(filePath));

            vfs.Add(filePath, newContent);

            // Assert
            Assert.Equal(newContent, vfs.Get(filePath));
            Assert.Single(vfs.Files); // Should still be only one file
        }

        [Fact]
        public void OpenRead_NonExistentFile_ThrowsException()
        {
            // Arrange
            using var vfs = new VirtualFileSystem();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => vfs.OpenRead("nonexistent.txt"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        [InlineData("\n")]
        public void FilePath_WithWhitespace_HandlesCorrectly(string filePath)
        {
            // Arrange
            using var vfs = new VirtualFileSystem();
            var content = "test content"u8.ToArray();

            // Act
            vfs.Add(filePath, content);

            // Assert
            Assert.True(vfs.Exists(filePath));
            Assert.Equal(content, vfs.Get(filePath));
        }
    }
}