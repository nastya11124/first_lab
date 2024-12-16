using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using App1.CoreSpace;
using App1.CoreSpace.Interfaces;


namespace TestApp1
{
    public class CatalogTest
    {
        [Fact]
        public void AddTrackOperation_ShouldReturnTrue_WhenTrackAddedSuccessfully()
        {
            // Arrange
            var mockDataChanger = new Mock<IDataChanger>();
            mockDataChanger.Setup(d => d.AddTrack("Author", "TrackName")).Returns(true);

            var catalog = new Catalog(mockDataChanger.Object, null);

            // Act
            var result = catalog.AddTrackOperation("Author", "TrackName");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddTrackOperation_ShouldReturnFalse_WhenTrackAdditionFails()
        {
            // Arrange
            var mockDataChanger = new Mock<IDataChanger>();
            mockDataChanger.Setup(d => d.AddTrack("Author", "TrackName")).Returns(false);

            var catalog = new Catalog(mockDataChanger.Object, null);

            // Act
            var result = catalog.AddTrackOperation("Author", "TrackName");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ShowAllTracksOperation_ShouldReturnCorrectData()
        {
            // Arrange
            var mockDataSearcher = new Mock<IDataSearcher>();
            var expectedData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1", "Track2" } },
                { "Author2", new List<string> { "Track3" } }
            };
            mockDataSearcher.Setup(d => d.Search()).Returns(expectedData);

            var catalog = new Catalog(null, mockDataSearcher.Object);

            // Act
            var result = catalog.ShowAllTracksOperation();

            // Assert
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public void FilterTrackOperation_ShouldReturnCorrectData_WhenFilteringByAuthor()
        {
            // Arrange
            var mockDataSearcher = new Mock<IDataSearcher>();
            var expectedData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1", "Track2" } }
            };
            mockDataSearcher.Setup(d => d.Search("Author1", true)).Returns(expectedData);

            var catalog = new Catalog(null, mockDataSearcher.Object);

            // Act
            var result = catalog.FilterTrackOperation("Author1", true);

            // Assert
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public void FilterTrackOperation_ShouldReturnCorrectData_WhenFilteringByName()
        {
            // Arrange
            var mockDataSearcher = new Mock<IDataSearcher>();
            var expectedData = new Dictionary<string, List<string>>
            {
                { "Author1", new List<string> { "Track1" } }
            };
            mockDataSearcher.Setup(d => d.Search("Track1", false)).Returns(expectedData);

            var catalog = new Catalog(null, mockDataSearcher.Object);

            // Act
            var result = catalog.FilterTrackOperation("Track1", false);

            // Assert
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public void DeleteTrackOperation_ShouldReturnTrue_WhenTrackDeletedSuccessfully()
        {
            // Arrange
            var mockDataChanger = new Mock<IDataChanger>();
            mockDataChanger.Setup(d => d.DeleteTrack("Author", "TrackName")).Returns(true);

            var catalog = new Catalog(mockDataChanger.Object, null);

            // Act
            var result = catalog.DeleteTrackOperation("Author", "TrackName");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteTrackOperation_ShouldReturnFalse_WhenTrackDeletionFails()
        {
            // Arrange
            var mockDataChanger = new Mock<IDataChanger>();
            mockDataChanger.Setup(d => d.DeleteTrack("Author", "TrackName")).Returns(false);

            var catalog = new Catalog(mockDataChanger.Object, null);

            // Act
            var result = catalog.DeleteTrackOperation("Author", "TrackName");

            // Assert
            Assert.False(result);
        }
    }
}
