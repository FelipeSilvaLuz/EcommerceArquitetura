using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class VendasController : Controller
    {
        private readonly IVendaAppService _vendaAppService;

        public VendasController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}