using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoAppService _carrinhoAppService;

        public CarrinhoController(ICarrinhoAppService carrinhoAppService)
        {
            _carrinhoAppService = carrinhoAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}