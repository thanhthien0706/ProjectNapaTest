using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Napa.BusinessLogic.IServices;
using Napa.Models;
using Napa.Utility;

namespace ProjectNapaTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_categoryService.IsNameAndDisplayOrderMatch(category))
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _categoryService.Create(category);
                TempData["success"] = "Category created successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new
            {
                data = _categoryService.GetAll()
            }); ;
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Category? category = _categoryService.GetOne(id);

            return Json(new
            {
                data = category
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            bool status = true;
            string message = "";

            if (ModelState.IsValid)
            {
                bool updateCategory = _categoryService.Update(category);

                if (!updateCategory)
                {
                    status = false;
                    message = "Category updated failed";
                }
                else
                {
                    TempData["success"] = "Category updated successfully";
                    status = true;
                    message = "Category updated successfully";
                }
            }

            return Json(new
            {
                status = status,
                message = message,
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool checkDelete = _categoryService.Delete(id);

            if (!checkDelete)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while deleting"
                });
            }

            TempData["success"] = "Category deleted successfully";
            return Json(new
            {
                success = true,
                message = "Delete product successfully"
            });
        }
        #endregion
    }
}
