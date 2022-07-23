using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CarrinhosController : Controller
    {
        private readonly ICarrinhoAppService _carrinhosAppService;

        public CarrinhosController(ICarrinhoAppService carrinhosAppService)
        {
            _carrinhosAppService = carrinhosAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}