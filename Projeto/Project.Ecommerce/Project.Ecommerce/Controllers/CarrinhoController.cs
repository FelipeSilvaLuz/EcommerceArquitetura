using Microsoft.AspNetCore.Mvc;

namespace Project.Ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}