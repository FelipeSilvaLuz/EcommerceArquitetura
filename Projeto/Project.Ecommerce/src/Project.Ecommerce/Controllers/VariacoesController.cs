using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class VariacoesController : Controller
    {
        private readonly IVariacaoAppService _variacaoppservice;

        public VariacoesController(IVariacaoAppService variacaoAppService)
        {
            _variacaoppservice = variacaoAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}