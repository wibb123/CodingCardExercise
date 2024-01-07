using CodingCardExercise.Models;

namespace CodingCardExercise.Services
{

    public class ScoringService
    {
        public ScoringService() { }

        /// <summary>
        /// Takes in a comma separated list of cards and returns a score as a string
        /// or an error message as a string if the input is invalid.
        /// </summary>
        /// <param name="cardString">Comma separated list of cards.</param>
        /// <returns>Score as a string.</returns>
        public async Task<string> GetScoreFromCardString(string cardListString)
        {
            try
            {
                List<Card> cardList = await ConvertStringToCardList(cardListString);
                int result = await GetScoreFromCardList(cardList);
                return "Score: " + result.ToString();
            }
            catch (ApplicationException ex)
            {
                return "Error: " + ex.Message;
            }
        }
        /// <summary>
        /// Takes in List of cards and returns a score
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns>The score as an integer.</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<int> GetScoreFromCardList(List<Card> cardList)
        {
            int score = 0;
            List<Card> jokers = cardList.Where(x => x.IsJoker).ToList();
            if (jokers.Count > 2)
            {
                throw new ApplicationException("A hand cannot contain more than two Jokers.");
            }
            List<Card> otherCards = cardList.Where(x => !x.IsJoker).ToList();
            foreach (Card card in otherCards)
            {
                int countOfCard = otherCards.Where(x => x.TwoLetterRep == card.TwoLetterRep).Count();
                if (countOfCard > 1)
                {
                    throw new ApplicationException(card.TwoLetterRep + " is in the list " + countOfCard + " times. Cards cannot be duplicated.");
                }
                int cardScore = card.GetScore();
                score += cardScore;
            }
            foreach (Card card in jokers)
            {
                score *= 2;
            }

            return score;
        }
        /// <summary>
        /// Used to convert a string to a Card object.
        /// </summary>
        /// <param name="cardString"></param>
        /// <returns>The Card representation of the string.</returns>
        public async Task<Card> ConvertStringToCard(string cardString)
        {
            try
            {
                string twoLetterString = cardString.Trim();
                if (twoLetterString.Length != 2)
                {
                    throw new ApplicationException("'" + twoLetterString + "' - Card not recognised.");
                }
                else
                {
                    Card card = Card.New(twoLetterString);
                    return card;
                }
            }
            catch (ApplicationException)
            {
                throw;
            }
        }
        /// <summary>
        /// Converts a string to a List of cards.
        /// The string must be a comma-separated list of valid cards.
        /// </summary>
        /// <param name="cardListString"></param>
        /// <returns>List of Card objects.</returns>
        public async Task<List<Card>> ConvertStringToCardList(string cardListString)
        {
            try
            {
                List<Card> result = new();
                if (string.IsNullOrEmpty(cardListString))
                {
                    return result;
                }
                if (cardListString.Trim().StartsWith(","))
                {
                    throw new ApplicationException("The input cannot begin with a comma, please alter the input and try again.");
                }
                if (cardListString.Trim().EndsWith(","))
                {
                    throw new ApplicationException("The input cannot end with a comma, please alter the input and try again.");
                }
                List<string> strings = cardListString.Split(',').ToList();


                foreach (string cardString in strings)
                {
                    if (cardString.Trim().Length == 0)
                    {
                        throw new ApplicationException("You have entered 2 or more consecutive commas, please alter the input and try again.");
                    }
                    Card card = await ConvertStringToCard(cardString);
                    result.Add(card);
                }

                return result;
            }
            catch (ApplicationException)
            {
                throw;
            }
        }
    }
}
