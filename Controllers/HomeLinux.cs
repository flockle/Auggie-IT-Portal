using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Auggie_IT_Support_Portal.Controllers
{
    [Route("linux")]

    public class HomeLinuxController : Controller
    {
        private readonly ILogger<HomeLinuxController> _logger;

        public HomeLinuxController(ILogger<HomeLinuxController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {

            {
                ViewBag.Theme = "linux"; // or "windows"
                return View();
            }

        }
    }
}

