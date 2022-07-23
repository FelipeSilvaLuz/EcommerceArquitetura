using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecosController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}