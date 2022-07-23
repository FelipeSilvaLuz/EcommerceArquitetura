using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class CaracteristicasController : Controller
    {
        private readonly ICaracteristicasAppService _caracteristicasappservice;

        public CaracteristicasController(ICaracteristicasAppService caracteristicasappservice)
        {
            _caracteristicasappservice = caracteristicasappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}