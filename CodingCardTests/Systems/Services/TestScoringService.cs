using CodingCardExercise.Models;
using CodingCardTests.Fixtures;

namespace CodingCardTests.Systems
{
    public class TestScoringService
    {
        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardListStrings), MemberType = typeof(CardsFixture))]
        public async Task GetScoreFromCardString_OnSuccess_ReturnsString(string input)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            var result = await sut.GetScoreFromCardString(input);

            // Assert
            result.Should().BeOfType<string>();
        }
        
        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardListStringsWithScores), MemberType = typeof(CardsFixture))]
        public async Task GetScoreFromCardString_OnSuccess_ReturnsCorrectScore(string input, int expectedScore)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            var result = await sut.GetScoreFromCardString(input);

            // Assert
            result.Should().Be("Score: " + expectedScore.ToString());
        }

        [Theory]
        [MemberData(nameof(CardsFixture.InvalidCardListStrings), MemberType = typeof(CardsFixture))]
        public async Task GetScoreFromCardString_OnFail_ReturnsErrorString(string input)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            var result = await sut.GetScoreFromCardString(input);

            // Assert
            result.Should().BeOfType<string>();
            result.Should().StartWith("Error");
        }


        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardListStrings), MemberType = typeof(CardsFixture))]
        public async Task ConvertStringToCardList_OnSuccess_ReturnsListOfCards(string input)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            var result = await sut.ConvertStringToCardList(input);

            // Assert
            result.Should().BeOfType<List<Card>>();
        }

        [Theory]
        [MemberData(nameof(CardsFixture.InvalidCardListStrings), MemberType = typeof(CardsFixture))]
        public async Task ConvertStringToCardList_OnFail_ThrowsApplicationException(string input)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            Func<Task> act = async () => await sut.ConvertStringToCardList(input);

            // Assert
            await act.Should().ThrowAsync<ApplicationException>();
        }

        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardStrings), MemberType = typeof(CardsFixture))]
        [InlineData(" 2C ")]
        public async Task ConvertStringToCard_OnSuccess_ReturnsCard(string input)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            var result = await sut.ConvertStringToCard(input);

            // Assert
            result.Should().BeOfType<Card>();
        }

        [Theory]
        [MemberData(nameof(CardsFixture.InvalidCardStrings), MemberType = typeof(CardsFixture))]
        public async Task ConvertStringToCard_OnFail_ThrowsApplicationException(string input)
        {
            // Arrange
            var sut = new ScoringService();

            // Act
            Func<Task> act = async () => await sut.ConvertStringToCard(input);

            // Assert
            await act.Should().ThrowAsync<ApplicationException>();
        }

        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardLists), MemberType = typeof(CardsFixture))]
        public async Task GetScoreFromCardList_OnSuccess_ReturnsZeroOrMore(List<Card> cardList)
        {
            // Arrange
            var sut = new ScoringService();

            //Act
            var result = await sut.GetScoreFromCardList(cardList);

            // Assert
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [MemberData(nameof(CardsFixture.InvalidCardLists), MemberType = typeof(CardsFixture))]
        public async Task GetScoreFromCardList_OnFail_ThrowsApplicationException(List<Card> cardList)
        {
            // Arrange
            var sut = new ScoringService();

            //Act
            Func<Task> act = async () => await sut.GetScoreFromCardList(cardList);

            // Assert
            await act.Should().ThrowAsync<ApplicationException>();
        }

    }
}