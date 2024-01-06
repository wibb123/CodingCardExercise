using CodingCardExercise.Models;
using CodingCardExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingCardExercise.Controllers
{
    public class HomeController : Controller
    {
        public const string Name = "Home";
        private readonly ScoringService _scoringService;

        public HomeController(ScoringService scoringService)
        {
            _scoringService = scoringService;
        }

        /// <summary>
        /// Returns the start up view.
        /// </summary>
        /// <returns>Home Page as a View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Takes in a comma-separated list of cards and returns a score.
        /// </summary>
        /// <param name="stringOfCards"></param>
        /// <returns>Score of cards as a string.</returns>
        [HttpPost]
        public async Task<string> GetScore(string stringOfCards)
        {
            var result = await _scoringService.GetScoreFromCardString(stringOfCards);
            return result;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}