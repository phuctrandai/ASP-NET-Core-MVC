using ASP_NET_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_NET_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.SessionValue = HttpContext.Session.GetString("Key");
            ViewBag.TempDataValue = TempData.Peek("TempKey");

            ViewBag.ValueFromView = TempData["ValueFromView"];

            ViewData["2"] = "Data from Controller";

            return View();
        }

        public IActionResult Privacy()
        {
            HttpContext.Session.SetString("Key", "Value");

            TempData["TempKey"] = "TempData Value";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
