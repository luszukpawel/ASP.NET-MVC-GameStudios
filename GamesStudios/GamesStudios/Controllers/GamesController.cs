using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesStudios.Models;

namespace GamesStudios.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Random()
        {
            var game = new Game() { Name = "The Wish" };

            return View(game);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //  if (pageIndex.HasValue) pageIndex = 1;
            //  if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            var games = GetGames();

            return View(games);

        }

   

        private IEnumerable<Game> GetGames()
        {
            return new List<Game>
            {
                new Game { Id = 1, Name = "Shrek" },
                new Game { Id = 2, Name = "Wall-e" }
            };
        }
    }
}