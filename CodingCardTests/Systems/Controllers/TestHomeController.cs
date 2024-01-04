namespace CodingCardTests.Systems.Controllers
{
    public class TestHomeController
    {
        [Fact]
        public async Task GetScore_OnSuccess_ReturnsString()
        {
            var mockScoringService = new Mock<IScoringService>();
            var sut = new HomeController(mockScoringService.Object);

            var result = await sut.GetScore("test");

            result.GetType().Should().Be(typeof(string));
        }

        [Fact]
        public async Task GetScore_OnSuccess_InvokesScoringServiceExactlyOnce()
        {
            var mockScoringService = new Mock<IScoringService>();
            mockScoringService.Setup(service => service.RetrieveCardList()).ReturnsAsync(new List<Card>());
            var sut = new HomeController(mockScoringService.Object);

            var result = await sut.GetScore("test");

            mockScoringService.Verify(service => service.RetrieveCardList(), Times.Once());
        }

    }
}