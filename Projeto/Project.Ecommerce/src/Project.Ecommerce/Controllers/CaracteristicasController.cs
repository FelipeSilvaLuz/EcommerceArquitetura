using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CaracteristicasController : Controller
    {
        private readonly ICaracteristicaAppService _caracteristicaAppService;

        public CaracteristicasController(ICaracteristicaAppService caracteristicaAppService)
        {
            _caracteristicaAppService = caracteristicaAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}