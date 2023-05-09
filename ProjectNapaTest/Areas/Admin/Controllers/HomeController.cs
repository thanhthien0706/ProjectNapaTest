using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Napa.Utility;

namespace ProjectNapaTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
