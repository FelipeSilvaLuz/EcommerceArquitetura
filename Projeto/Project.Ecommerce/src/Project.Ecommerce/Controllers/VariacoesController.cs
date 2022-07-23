using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class VariacoesController : Controller
    {
        private readonly IVariacoesAppService _variacoesappservice;

        public VariacoesController(IVariacoesAppService variacoesappservice)
        {
            _variacoesappservice = variacoesappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}