using CodingCardTests.Fixtures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace CodingCardTests.Systems
{
    public class TestHomeController
    {
        [Fact]
        public void Index_OnSuccess_ReturnsView()
        {
            // Arrange
            var mockScoringService = new Mock<ScoringService>();
            var sut = new HomeController(mockScoringService.Object);

            // Act
            var result = sut.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }


        [Fact]
        public async Task GetScore_OnSuccess_ReturnsString()
        {
            // Arrange
            var mockScoringService = new Mock<ScoringService>();
            var sut = new HomeController(mockScoringService.Object);

            // Act
            var result = await sut.GetScore("test");

            // Assert
            result.GetType().Should().Be(typeof(string));
        }

        [Fact]
        public async Task GetScore_OnSuccess_InvokesScoringServiceExa()
        {
            // Arrange
            var mockScoringService = new Mock<ScoringService>();
            var sut = new HomeController(mockScoringService.Object);

            // Act
            var result = await sut.GetScore("JD");

            // Assert
            result.Should().BeOfType<string>();
        }

    }
}