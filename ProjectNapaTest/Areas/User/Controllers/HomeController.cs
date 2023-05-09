using Microsoft.AspNetCore.Mvc;
using Napa.BusinessLogic.IServices;
using Napa.Models;
using System.Diagnostics;

namespace ProjectNapaTest.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(ILogger<HomeController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {
            _testService.DoSomething();
            return View();
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