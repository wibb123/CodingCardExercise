using CodingCardExercise.Models.Enums;

namespace CodingCardExercise.Models
{
    /// <summary>
    /// Representation of a Playing Card
    /// </summary>
    public class Card
    {
        public const string JokerString = "JK";
        public Card()
        {
        }
        /// <summary>
        /// Creates a new card object from a two letter representation.
        /// e.g. AS => Ace of Spades
        /// e.g. JK => Joker
        /// e.g. 2C => Two of Clubs
        /// </summary>
        /// <param name="twoLetterRep">The two letter representation of the playing card.</param>
        /// <returns>A new Card object.</returns>
        /// <exception cref="ApplicationException"></exception>
        public static Card New(string twoLetterRep)
        {
            if (twoLetterRep == JokerString)
            {
                Card card = new()
                {
                    TwoLetterRep = twoLetterRep,
                    IsJoker = true
                };
                return card;
            }
            else
            {
                try
                {
                    Card card = new()
                    {
                        TwoLetterRep = twoLetterRep,
                        IsJoker = false,
                        Rank = Helpers.ParseEnumByOneCharRep<Rank>(twoLetterRep[0]),
                        Suit = Helpers.ParseEnumByOneCharRep<Suit>(twoLetterRep[1]),
                    };
                    return card;
                }
                catch
                {
                    throw new ApplicationException(twoLetterRep + " - card not recognised.");
                }
            }
        }
        /// <summary>
        /// Calculates the score for the card.
        /// </summary>
        /// <returns>The score as an integer.</returns>
        public int GetScore()
        {
            if (!IsJoker)
            {
                return (int)Rank * (int)Suit;
            }
            else return 0;
        }

        public string TwoLetterRep { get; set; }
        public bool IsJoker { get; set; }
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

    }
}
