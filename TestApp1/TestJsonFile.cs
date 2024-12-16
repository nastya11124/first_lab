
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Moq;
using App1.CoreSpace;
using App1.CoreSpace.Interfaces;
using App1.UserInterface;

namespace App1.Tests
{
    public class JsonFileTests
    {
        [Fact]
        public async Task LoadFromFile_FileDoesNotExist_ReturnsEmptyDictionary()
        {
            // Arrange
            using var tempFile = new TemporaryFile();
            var jsonFile = new JsonFile(tempFile.FilePath);

            // Act
            var result = await jsonFile.LoadFromFile();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task LoadFromFile_FileExists_ReturnsDeserializedDictionary()
        {
            // Arrange
            using var tempFile = new TemporaryFile();
            var expectedData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1", "Track2" } },
                { "Author2", new List<string> { "Track3" } }
            };
            var json = JsonSerializer.Serialize(expectedData);
            File.WriteAllText(tempFile.FilePath, json);

            var jsonFile = new JsonFile(tempFile.FilePath);

            // Act
            var result = await jsonFile.LoadFromFile();

            // Assert
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public async Task LoadFromFile_DeserializationFails_ReturnsEmptyDictionary()
        {
            // Arrange
            using var tempFile = new TemporaryFile();
            var invalidJson = "invalid json";
            File.WriteAllText(tempFile.FilePath, invalidJson);

            var jsonFile = new JsonFile(tempFile.FilePath);

            // Act
            var result = await jsonFile.LoadFromFile();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task SaveToFile_ValidData_SavesToFile()
        {
            // Arrange
            using var tempFile = new TemporaryFile();
            var data = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1", "Track2" } },
                { "Author2", new List<string> { "Track3" } }
            };

            var jsonFile = new JsonFile(tempFile.FilePath);

            // Act
            await jsonFile.SaveToFile(data);

            // Assert
            var json = await File.ReadAllTextAsync(tempFile.FilePath);
            var deserializedData = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
            Assert.Equal(data, deserializedData);
        }

        [Fact]
        public async Task SaveToFile_DirectoryNotFoundException_ThrowsException()
        {
            // Arrange
            var invalidPath = @"C:\non_existent_directory\test_music_catalog.json";
            var data = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1", "Track2" } },
                { "Author2", new List<string> { "Track3" } }
            };

            var jsonFile = new JsonFile(invalidPath);

            // Act & Assert
            await Assert.ThrowsAsync<DirectoryNotFoundException>(() => jsonFile.SaveToFile(data));
        }

    }
}