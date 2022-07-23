using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class PerfisController : Controller
    {
        private readonly IPerfisAppService _PerfisAppService;

        public PerfisController(IPerfisAppService PerfisAppService)
        {
            _PerfisAppService = PerfisAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}