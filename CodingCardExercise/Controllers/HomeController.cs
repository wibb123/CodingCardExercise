using CodingCardExercise.Models;
using CodingCardExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingCardExercise.Controllers
{
    public class HomeController : Controller
    {
        public const string Name = "Home";
        private readonly IScoringService _scoringService;

        public HomeController(IScoringService scoringService)
        {
            _scoringService = scoringService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> GetScore(string stringOfCards)
        {
            var result = 1;
            var cards = await _scoringService.RetrieveCardList();
            string stringResult = result.ToString();
            return stringResult;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}