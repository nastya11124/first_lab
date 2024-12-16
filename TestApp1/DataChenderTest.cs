using App1.CoreSpace;
using App1.CoreSpace.Interfaces;
using Moq;


namespace TestApp1
{
    public class DataChangerTests
    {
        [Fact]
        public void AddTrack_AddNewTrackToExistingAuthor_ReturnsTrue()
        {
            // Arrange
            var mockDb = new Mock<AbstractDataBase>();
            var initialData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1" } }
            };
            mockDb.Setup(db => db.GetCatalog()).Returns(initialData);

            var dataChanger = new DataChanger(mockDb.Object);

            // Act
            var result = dataChanger.AddTrack("Author1", "Track2");

            // Assert
            Assert.True(result);
            Assert.Contains("Track2", initialData["Author1"]);
        }

        [Fact]
        public void AddTrack_AddNewTrackToNewAuthor_ReturnsTrue()
        {
            // Arrange
            var mockDb = new Mock<AbstractDataBase>();
            var initialData = new Dictionary<string, List<string>>();
            mockDb.Setup(db => db.GetCatalog()).Returns(initialData);

            var dataChanger = new DataChanger(mockDb.Object);

            // Act
            var result = dataChanger.AddTrack("Author2", "Track3");

            // Assert
            Assert.True(result);
            Assert.Contains("Author2", initialData.Keys);
            Assert.Contains("Track3", initialData["Author2"]);
        }

        [Fact]
        public void AddTrack_AddDuplicateTrack_ReturnsFalse()
        {
            // Arrange
            var mockDb = new Mock<AbstractDataBase>();
            var initialData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1" } }
            };
            mockDb.Setup(db => db.GetCatalog()).Returns(initialData);

            var dataChanger = new DataChanger(mockDb.Object);

            // Act
            var result = dataChanger.AddTrack("Author1", "Track1");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteTrack_DeleteExistingTrack_ReturnsTrue()
        {
            // Arrange
            var mockDb = new Mock<AbstractDataBase>();
            var initialData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1", "Track2" } }
            };
            mockDb.Setup(db => db.GetCatalog()).Returns(initialData);

            var dataChanger = new DataChanger(mockDb.Object);

            // Act
            var result = dataChanger.DeleteTrack("Author1", "Track1");

            // Assert
            Assert.True(result);
            Assert.DoesNotContain("Track1", initialData["Author1"]);
        }

        [Fact]
        public void DeleteTrack_DeleteLastTrack_RemovesAuthor_ReturnsTrue()
        {
            // Arrange
            var mockDb = new Mock<AbstractDataBase>();
            var initialData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1" } }
            };
            mockDb.Setup(db => db.GetCatalog()).Returns(initialData);

            var dataChanger = new DataChanger(mockDb.Object);

            // Act
            var result = dataChanger.DeleteTrack("Author1", "Track1");

            // Assert
            Assert.True(result);
            Assert.False(initialData.ContainsKey("Author1"));
        }

        [Fact]
        public void DeleteTrack_DeleteNonExistingTrack_ReturnsFalse()
        {
            // Arrange
            var mockDb = new Mock<AbstractDataBase>();
            var initialData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1" } }
            };
            mockDb.Setup(db => db.GetCatalog()).Returns(initialData);

            var dataChanger = new DataChanger(mockDb.Object);

            // Act
            var result = dataChanger.DeleteTrack("Author1", "Track2");

            // Assert
            Assert.False(result);
        }
    }
}
