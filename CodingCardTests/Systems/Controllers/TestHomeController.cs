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


        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardListStrings), MemberType = typeof(CardsFixture))]
        public async Task GetScore_OnSuccess_ReturnsString(string input)
        {
            // Arrange
            var mockScoringService = new Mock<ScoringService>();
            var sut = new HomeController(mockScoringService.Object);

            // Act
            var result = await sut.GetScore(input);

            // Assert
            result.Should().BeOfType<string>();
        }

        [Theory]
        [MemberData(nameof(CardsFixture.InvalidCardListStrings), MemberType = typeof(CardsFixture))]
        public async Task GetScore_OnFail_ReturnsErrorString(string input)
        {
            // Arrange
            var mockScoringService = new Mock<ScoringService>();
            var sut = new HomeController(mockScoringService.Object);

            // Act
            var result = await sut.GetScore(input);

            // Assert
            result.Should().BeOfType<string>();
            result.Should().StartWith("Error");
        }

    }
}