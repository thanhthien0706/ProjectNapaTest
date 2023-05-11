using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Napa.BusinessLogic;
using Napa.BusinessLogic.IServices;
using Napa.Models;
using Napa.Utility;

namespace ProjectNapaTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
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
        public IActionResult Create(Author data)
        {
            if (ModelState.IsValid)
            {
                _authorService.Create(data);
                TempData["success"] = "Author created successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(data);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new
            {
                data = _authorService.GetAll()
            }); ;
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Author? data = _authorService.GetOne(id);

            return Json(new
            {
                data = data
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, Author author)
        {
            bool status = true;
            string message = "";

            if (ModelState.IsValid)
            {
                bool updateData = _authorService.Update(author);

                if (!updateData)
                {
                    status = false;
                    message = "Author updated failed";
                }
                else
                {
                    TempData["success"] = "Author updated successfully";
                    status = true;
                    message = "Author updated successfully";
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
            bool checkDelete = _authorService.Delete(id);

            if (!checkDelete)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while deleting"
                });
            }

            TempData["success"] = "Author deleted successfully";
            return Json(new
            {
                success = true,
                message = "Delete Author successfully"
            });
        }
        #endregion
    }
}
