using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Napa.BusinessLogic.IServices;
using Napa.Models;
using Napa.Models.ViewModels;
using Napa.Utility;
using System.Data;

namespace ProjectNapaTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BookController : Controller
    {
        public readonly IBookService _bookService;
        public readonly IAuthorService _authorService;
        public readonly ICategoryService _categoryService;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpSert(int? id)
        {
            IEnumerable<SelectListItem> categories = _categoryService.GetAll().Select(u => new SelectListItem
            {
                Text = u.Title,
                Value = u.Id.ToString()
            });

            IEnumerable<SelectListItem> authors = _authorService.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            BookAdminVM bookAdminVM = new BookAdminVM()
            {
                CategoryList = categories,
                AuthorList = authors,
                Book = new Book() { }
            };

            if (!(id == null || id == 0))
            {
                bookAdminVM.Book = _bookService.Get(u => u.Id == id);

            }

            return View(bookAdminVM);
        }

        [HttpPost]
        public IActionResult Upsert(BookAdminVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string producrPath = Path.Combine(wwwRootPath, @"images\book");

                    if (!string.IsNullOrEmpty(obj.Book.Thumbnail))
                    {
                        var oldImagePath =
                            Path.Combine(wwwRootPath, obj.Book.Thumbnail.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(producrPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Book.Thumbnail = @"\images\book\" + fileName;
                }

                if (obj.Book.Id == 0)
                {
                    _bookService.Create(obj.Book);
                }
                else
                {
                    _bookService.Update(obj.Book);
                }

                TempData["success"] = "Book created successfully";

                return RedirectToAction(nameof(Index));
            }

            else
            {
                obj.CategoryList = _categoryService.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Title,
                    Value = u.Id.ToString()
                });

                obj.AuthorList = _authorService.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(obj);
            }

        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> products = _bookService.GetAll().ToList();

            return Json(new
            {
                data = products
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book? oldData = _bookService.Get(u => u.Id == id);

            if (oldData == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while deleting"
                });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, oldData.Thumbnail.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _bookService.Delete(oldData);
            TempData["success"] = "Book deleted successfully";

            return Json(new
            {
                success = true,
                message = "Delete book successfully"
            });
        }

        #endregion
    }
}
