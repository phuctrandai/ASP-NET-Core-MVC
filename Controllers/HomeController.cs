using Microsoft.AspNetCore.Mvc;

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
            throw new FileNotFoundException("Testing");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}