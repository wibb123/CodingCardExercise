using CodingCardExercise.Models;

namespace CodingCardExercise.Services
{
    public interface IScoringService
    {
        public Task<List<Card>> RetrieveCardList();
    }

    public class ScoringService : IScoringService
    {
        public ScoringService() { }

        public Task<List<Card>> RetrieveCardList()
        {
            throw new NotImplementedException();
        }
    }
}
