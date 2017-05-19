using Microsoft.AspNetCore.Mvc;
using Polygamy.Security;

namespace Polygamy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Aplicación Polygamy - ING SOFT II - MCIC";

            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
