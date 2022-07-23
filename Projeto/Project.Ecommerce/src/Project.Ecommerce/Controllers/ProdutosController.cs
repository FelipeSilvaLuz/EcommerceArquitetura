using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutosAppService _produtosappservice;

        public ProdutosController(IProdutosAppService produtosappservice)
        {
            _produtosappservice = produtosappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}