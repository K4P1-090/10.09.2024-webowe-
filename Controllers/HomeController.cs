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
    [HttpGet]
    public IActionResult AddNewGame()
    {
        return View();
    }
    [HttpPost]
        public IActionResult AddNewGame(Game game)
        {
            if(ModelState.IsValid){
                _gamesRepo.AddGame(game);
                return RedirectToAction("Index");
            }
            return View();
        }
    [HttpGet]
        public IActionResult UpdateGame(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var game = _gamesRepo.GetGames().FirstOrDefault(b => b.Id == id);
            return View(game);
        }
        [HttpPost]
        public IActionResult UpdateGame(Game game)
        {
            if (ModelState.IsValid)
            {
                var toUpdate = _gamesRepo.GetGames().FirstOrDefault(b => b.Id == game.Id);
                if(toUpdate == null)
                {
                    return RedirectToAction("Index");
                }
                toUpdate.Title = game.Title ;
                toUpdate.Cathegory = game.Cathegory;
                toUpdate.Year=game.Year;
                toUpdate.Price = game.Price;
                _gamesRepo.UpdateGame(toUpdate);
                return RedirectToAction("Index");
            }
            return View(game);
        }
    public IActionResult DeleteGame(int id)
        {
            _gamesRepo.DeleteGame(id);
            return RedirectToAction("Index");
        }    
    public IActionResult OrderedBoks(string? sort)
        {
            List<Game> games;
            if (sort == "asc")
            {
                games = _gamesRepo.GetGames().OrderBy(x => x.Title).ToList();
            }
            else
            {
                games = _gamesRepo.GetGames().OrderByDescending(x => x.Title).ToList();
            }

            ViewBag.Sort = sort == "asc" ? "desc" : "asc";
            return View("Index", games);
        }    
}
