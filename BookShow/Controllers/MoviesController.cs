using BookShow.Data;
using BookShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShow.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db
;        public MoviesController( ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Movies>  objMovieCategoryList = _db.Movies.ToList();
            return View(objMovieCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movies obj) 
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order And name can not be Same");
            }
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie Category Created Successfully";

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit( int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Movies? movieCatFromDb = _db.Movies.Find(id);
           // Movies movieCatFromDb1 = _db.Movies.FirstOrDefault(u=>u.Id==id);
            if(movieCatFromDb==null)
            {
                return NotFound();
            }
            return View(movieCatFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Movies obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie Category Edited Successfully";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movies? movieCatFromDb = _db.Movies.Find(id);
            // Movies movieCatFromDb1 = _db.Movies.FirstOrDefault(u=>u.Id==id);
            if (movieCatFromDb == null)
            {
                return NotFound();
            }
            return View(movieCatFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Movies? obj = _db.Movies.Find(id); 
            if (obj==null)
            {
                return NotFound();
            }
            _db.Movies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie Category Deleted Successfully";
            return RedirectToAction("Index");
            
        }
    }
}
