using IMASDB.Data;
using IMASDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace IMASDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Movie> movieListObj = _db.Movies.ToList();
            return View(movieListObj);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Reminder"] = "Please make sure the movie you want to add is not already added. Thanks for your contribution!";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie obj)
        {
            if(ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                ViewBag.SuccessMessage = "Movie successfully added!";
                return View("Index", _db.Movies.ToList());
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Movie? movieToEdit = _db.Movies.Find(id);
            if(movieToEdit == null)
            {
                return NotFound();
            }
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                ViewBag.SuccessMessage = "Movie successfully edited!";
                return View(obj);
            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movie? movieToEdit = _db.Movies.Find(id);
            if (movieToEdit == null)
            {
                return NotFound();
            }
            return View(movieToEdit);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Movie? obj = _db.Movies.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Movies.Remove(obj);
            _db.SaveChanges();
            ViewBag.SuccessMessage = "Movie successfully removed!";
            return View("Index", _db.Movies.ToList());

        }
    }
}
