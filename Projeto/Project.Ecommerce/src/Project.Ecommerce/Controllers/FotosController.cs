using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class FotosController : Controller
    {
        private readonly IFotoAppService _fotoAppService;

        public FotosController(IFotoAppService fotoAppService)
        {
            _fotoAppService = fotoAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}