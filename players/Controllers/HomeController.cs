using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using players.Models;

namespace players.Controllers
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
            var levels = new List<List<string>>
            {
                new() { "A Thành", "A Trung" },
                new() { "SaoNM", "SơnTH/Quân" },
                new() { "Luân", "A Việt" },
                new() { "A Dũng (Việt Software)", "A Hà / A Liêm" },
                new() { "Công", "Quyền" },
                new() { "Hoàng", "Hinh" },
                new() { "A Dũng Đăng", "Dương / Long" },
                new() { "Hưng", "Tô Sơn" }
            };

            ViewBag.Levels = levels;
            return View();
        }

        [HttpPost]
        public IActionResult RandomizeTeams(List<List<string>> levels)
        {
            var team1 = new List<string>();
            var team2 = new List<string>();
            var rand = new Random();

            foreach (var level in levels)
            {
                if (level.Count < 2) continue;

                if (rand.Next(2) == 0)
                {
                    team1.Add(level[0]);
                    team2.Add(level[1]);
                }
                else
                {
                    team1.Add(level[1]);
                    team2.Add(level[0]);
                }
            }

            ViewBag.Team1 = team1;
            ViewBag.Team2 = team2;
            ViewBag.Levels = levels;
            return View("Index");
        }

        public IActionResult Privacy()
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
