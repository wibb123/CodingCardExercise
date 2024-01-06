using CodingCardTests.Fixtures;

namespace CodingCardTests.Systems
{
    public class TestCard
    {
        [Fact]
        public void GetScore_OnSuccess_ReturnsZeroOrMore()
        {
            // Arrange
            var sut = new Card();

            // Act
            var result = sut.GetScore();

            // Assert
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardsWithScores), MemberType = typeof(CardsFixture))]
        public async Task GetScore_OnSuccess_ReturnsCorrectValue(Card card, int expectedScore)
        {
            // Arrange
            var sut = card;

            // Act
            var result = sut.GetScore();

            // Assert
            result.Should().Be(expectedScore);
        }

        [Theory]
        [MemberData(nameof(CardsFixture.ValidCardStrings), MemberType = typeof(CardsFixture))]
        public void New_OnSuccess_ReturnsCard(string input)
        {
            // Act
            var result = Card.New(input);

            // Assert
            result.Should().BeOfType<Card>();
        }

        [Theory]
        [MemberData(nameof(CardsFixture.InvalidCardStrings), MemberType = typeof(CardsFixture))]
        public void New_OnFail_ThrowsApplicationException(string input)
        {
            // Arrange
            var sut = new Card();

            // Act
            Action act = () => Card.New(input);

            // Assert
            act.Should().Throw<ApplicationException>();
        }



    }
}