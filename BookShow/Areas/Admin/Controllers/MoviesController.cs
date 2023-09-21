using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShow.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Movies> objMovieCategoryList = _unitOfWork.Movies.GetAll().ToList();
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
                _unitOfWork.Movies.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Movie Category Created Successfully";

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movies? movieCatFromDb = _unitOfWork.Movies.Get(u => u.Id == id);
            // Movies movieCatFromDb1 = _db.Movies.FirstOrDefault(u=>u.Id==id);
            if (movieCatFromDb == null)
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
                _unitOfWork.Movies.Update(obj);
                _unitOfWork.Save();
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
            Movies? movieCatFromDb = _unitOfWork.Movies.Get(u => u.Id == id);
            // Movies movieCatFromDb1 = _db.Movies.FirstOrDefault(u=>u.Id==id);
            if (movieCatFromDb == null)
            {
                return NotFound();
            }
            return View(movieCatFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Movies? obj = _unitOfWork.Movies.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Movies.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Movie Category Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
