using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SEP241_ASPNET.Models;

namespace SEP241_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Hello STEP";
            List<string> list = new List<string>()
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
            ViewData["list"] = list;
            return View();
        }      
        
        public IActionResult About()
        {
            return View();
        }
    }
}
