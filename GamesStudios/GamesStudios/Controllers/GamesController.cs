using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using GamesStudios.Models;

namespace GamesStudios.Controllers
{
    public class GamesController : Controller
    {

        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);

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