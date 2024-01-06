namespace CodingCardTests.Systems
{
    public class TestHelpers
    {
        [Theory]
        [InlineData('C', Suit.Club)]
        [InlineData('H', Suit.Heart)]
        [InlineData('D', Suit.Diamond)]
        [InlineData('S', Suit.Spade)]
        [InlineData('A', Rank.Ace)]
        [InlineData('Q', Rank.Queen)]
        [InlineData('K', Rank.King)]
        [InlineData('9', Rank.Nine)]
        [InlineData('T', Rank.Ten)]
        [InlineData('4', Rank.Four)]
        [InlineData('3', Rank.Three)]
        public void ParseEnumByOneCharRep_OnSuccess_ReturnsEnum<TEnum>(char character, TEnum expectedEnum) where TEnum : Enum
        {
            // Arrange

            // Act
            var result = Helpers.ParseEnumByOneCharRep<TEnum>(character);

            // Assert
            result.Should().Be(expectedEnum);
        }
    }
}