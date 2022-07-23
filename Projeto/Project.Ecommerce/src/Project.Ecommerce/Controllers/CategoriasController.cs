using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasAppService _categoriasappservice;

        public CategoriasController(ICategoriasAppService categoriasappservice)
        {
            _categoriasappservice = categoriasappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}