using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.Ecommerce.Controllers
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
            return View();
        }

        [Route("/Detalhes")]
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}