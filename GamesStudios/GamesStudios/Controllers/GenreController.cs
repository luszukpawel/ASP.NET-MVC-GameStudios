using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GamesStudios.Models;
using GamesStudios.ViewModels;


namespace GamesStudios.Controllers
{
    public class GenresController : Controller
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new GenreFormViewModel();

            return View("GenreForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Genre Genre)
        {
            if (Genre.Id == 0)
                _context.Genres.Add(Genre);
            else
            {
                var GenreInDb = _context.Genres.Single(c => c.Id == Genre.Id);
                GenreInDb.Name = Genre.Name;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ViewResult Index()
        {
            return View();
        }


    }
}