using ASP_NET_Core_MVC.Models;
using ASP_NET_Core_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_NET_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        //private readonly IScopedService _simpleService;

        public HomeController(ILogger<HomeController> logger, 
            ITransientService transientService1, ITransientService transientService2,
            IScopedService scopedService1, IScopedService scopedService2,
            ISingletonService singletonService1, ISingletonService singletonService2, 
            IScopedService simpleService)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            //_simpleService = simpleService;
        }

        public IActionResult Index()
        {
            ViewBag.TransientService1Id = _transientService1.GetID();
            ViewBag.TransientService2Id = _transientService2.GetID();

            ViewBag.ScopedService1Id = _scopedService1.GetID();
            ViewBag.ScopedService2Id = _scopedService2.GetID();

            ViewBag.SingletonService1Id = _singletonService1.GetID();
            ViewBag.SingletonService2Id = _singletonService2.GetID();

            //ViewBag.SimpleServiceId = _simpleService.GetID();
            //ViewBag.SimpleServiceChild1Id = _simpleService.GetChildService1ID();
            //ViewBag.SimpleServiceChild2Id = _simpleService.GetChildService2ID();

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