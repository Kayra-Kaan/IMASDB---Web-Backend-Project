using IMASDB.Data;
using IMASDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMASDB.Controllers
{
    public class ShowController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShowController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Show> showListObj = _db.Shows.ToList();
            return View(showListObj);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Reminder"] = "Please make sure the show you want to add is not already added. Thanks for your contribution! ";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Show obj)
        {
            if (ModelState.IsValid)
            {
                _db.Shows.Add(obj);
                _db.SaveChanges();
                ViewBag.SuccessMessage = "Show successfully added!";
                return View("Index", _db.Shows.ToList());
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Show? showToEdit = _db.Shows.Find(id);
            if (showToEdit == null)
            {
                return NotFound();
            }
            return View(showToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Show obj)
        {
            if (ModelState.IsValid)
            {
                _db.Shows.Update(obj);
                _db.SaveChanges();
                ViewBag.SuccessMessage = "Show successfully edited!";
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
            Show? showToDelete = _db.Shows.Find(id);
            if (showToDelete == null)
            {
                return NotFound();
            }
            return View(showToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Show? obj = _db.Shows.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Shows.Remove(obj);
            _db.SaveChanges();
            ViewBag.SuccessMessage = "Show successfully removed!";
            return View("Index", _db.Shows.ToList());

        }
    }
}
