using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriasAppService;

        public CategoriasController(ICategoriaAppService categoriasAppService)
        {
            _categoriasAppService = categoriasAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}