using Azure;
using Microsoft.AspNetCore.Mvc;
using Napa.BusinessLogic.IServices;
using Napa.Models;
using Napa.Utility;
using System.Diagnostics;
using X.PagedList;

namespace ProjectNapaTest.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Index(int page = 1)
        {
            page = page < 1 ? 1 : page;
            IEnumerable<Book> bookList = _bookService.GetAll().Where(b => b.Published == true).ToPagedList(page
                , SD.Page_Size);
            return View(bookList);
        }

        public IActionResult Detail(int id)
        {
            Book data = _bookService.Get(u => u.Id == id );
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}