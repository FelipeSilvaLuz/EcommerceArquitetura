using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class FotosController : Controller
    {
        private readonly IFotosAppService _fotosappservice;

        public FotosController(IFotosAppService fotosappservice)
        {
            _fotosappservice = fotosappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}