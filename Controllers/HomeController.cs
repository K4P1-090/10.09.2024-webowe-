using System.Diagnostics;
using _10._09._2024_webowe_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _10._09._2024_webowe_.Controllers;

public class HomeController : Controller
{
    private readonly GamesRepo _gamesRepo;
    public HomeController(IConfiguration configuration)
    {
        _gamesRepo=new GamesRepo();
    }
    
    public IActionResult Index(string sortOrder)
    {
        var games = _gamesRepo.GetGames();
        var gamesCountByYear = _gamesRepo.GetGamesCountByYear();

        ViewBag.GamesCountByYear = gamesCountByYear;
        ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

        if (!String.IsNullOrEmpty(sortOrder))
        {
            switch (sortOrder)
            {
                case "title_desc":
                    games = games.OrderBy(g => g.Title).ToList();
                    break;
                default:
                    games = games.OrderBy(g => g.Title).ToList();
                    break;
            }
        }

        return View(games);
    }
    public IActionResult Index1()
    {
        var games = _gamesRepo.GetGames();
        var gamesCountByYear = _gamesRepo.GetGamesCountByYear();
        ViewBag.GamesCountByYear = gamesCountByYear;
        return View(games);
    }

    public IActionResult AddNewGame()
    {
        return View();
    }

    
}
