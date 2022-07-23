using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CarrinhosController : Controller
    {
        private readonly ICarrinhosAppService _carrinhosAppService;

        public CarrinhosController(ICarrinhosAppService carrinhosAppService)
        {
            _carrinhosAppService = carrinhosAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}