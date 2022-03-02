using Flashcard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Flashcard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new FlascardViewModel
            {
                FCard = new Models.Flashcard
                {
                    Avers = new Flashpage
                    {
                        Word = "Home",
                        Description = "additional description",
                        Evaluation = 3
                    },
                    Revers = new Flashpage
                    {
                        Word = "Dom",
                        Description = "opis dodatkowy",
                        Evaluation = 2
                    }
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Flashcards()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}