using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class BancosController : Controller
    {
        private readonly IBancoAppService _bancoAppService;

        public BancosController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}