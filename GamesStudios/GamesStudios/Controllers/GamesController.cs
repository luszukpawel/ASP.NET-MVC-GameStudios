using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GamesStudios.Models;
using GamesStudios.ViewModels;


namespace Vidly.Controllers
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

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new GameFormViewModel
            {
                Game = new Game(),
                Genres = genres
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Game Game)
        {
            if (Game.Id == 0)
                _context.Games.Add(Game);
            else
            {
                var GameInDb = _context.Games.Single(c => c.Id == Game.Id);
                GameInDb.Name = Game.Name;
                GameInDb.GenreId = Game.GenreId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        public ViewResult Index()
        {
            var Games = _context.Games.Include(c => c.Genre).ToList();

            return View(Games);
        }

        public ActionResult Details(int id)
        {
            var Game = _context.Games.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (Game == null)
                return HttpNotFound();

            return View(Game);
        }

        public ActionResult Edit(int id)
        {
            var Game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (Game == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel
            {
                Game = Game,
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);
        }
    }
}