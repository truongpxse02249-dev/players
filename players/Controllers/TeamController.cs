using Microsoft.AspNetCore.Mvc;
using players.Models;
using System.Collections.Generic;

namespace players.Controllers
{
    public class TeamController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Dữ liệu mặc định – bạn có thể thay đổi
            var levels = new List<PlayerLevel>
            {
                new() { Id = 1, Player1 = "A Thành", Player2 = "A Trung" },
                new() { Id = 2, Player1 = "SaoNM", Player2 = "SơnTH/Quân" },
                new() { Id = 3, Player1 = "Luân", Player2 = "Việt" },
                new() { Id = 4, Player1 = "A Dũng (VietSoftware)", Player2 = "A Hà / A Liêm" },
                new() { Id = 5, Player1 = "Công", Player2 = "Quyến" },
                new() { Id = 6, Player1 = "Hoàng", Player2 = "Hinh" },
                new() { Id = 7, Player1 = "A Dũng Đăng", Player2 = "Dương / Long" },
                new() { Id = 8, Player1 = "Hưng", Player2 = "Tô Sơn" }
            };

            return View(levels);
        }

        [HttpPost]
        public IActionResult RandomizeTeams(List<PlayerLevel> levels)
        {
            var team1 = new List<string>();
            var team2 = new List<string>();
            var rand = new Random();

            foreach (var level in levels)
            {
                if (rand.Next(2) == 0)
                {
                    team1.Add(level.Player1);
                    team2.Add(level.Player2);
                }
                else
                {
                    team1.Add(level.Player2);
                    team2.Add(level.Player1);
                }
            }

            ViewBag.Team1 = team1;
            ViewBag.Team2 = team2;

            return View("Index", levels);
        }
    }
}
