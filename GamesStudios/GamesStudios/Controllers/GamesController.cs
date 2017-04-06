using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GamesStudios.Models;
using GamesStudios.ViewModels;
using GamesStudios.Controllers;


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

    [Authorize(Roles = RoleName.Admin)]
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
    [Authorize(Roles = RoleName.Admin)]
    public ActionResult Save(Game game)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new GameFormViewModel()
            {
                Game = game,
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);
        }

        if (game.Id == 0)
            _context.Games.Add(game);
        else
        {
            var customerInDb = _context.Games.Single(c => c.Id == game.Id);
            customerInDb.Name = game.Name;
            customerInDb.Description = game.Description;
            customerInDb.GenreId = game.GenreId;
            customerInDb.DownloadLink = game.DownloadLink;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Games");
    }

    public ViewResult Index()
    {
        
        var Games = _context.Games.Include(c => c.Genre).ToList();
        
        if (User.IsInRole(RoleName.Admin))
            return View("AdminIndex", Games);
        

        return View("Index", Games);
    }

    public ActionResult Details(int id)
    {
        ViewBag.Message = "Details of Game";
        var Game = _context.Games.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

        if (Game == null)
            return HttpNotFound();

        return View(Game);
    }

    [Authorize(Roles = RoleName.Admin)]
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
    [Authorize(Roles = RoleName.Admin)]
    public ActionResult Delete(int id)
    {
        Game game = _context.Games.Find(id);
        if (game == null)
        {
            return HttpNotFound();
        }
        _context.Games.Remove(game);
        _context.SaveChanges();
        return RedirectToAction("Index", "Games");
    }
}
