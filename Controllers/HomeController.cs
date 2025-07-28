using Auggie_IT_Support_Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Auggie_IT_Support_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IActionResult Support()
        {
            return View();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
