using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly IEnderecosAppService _enderecosappservice;

        public EnderecosController(IEnderecosAppService enderecosappservice)
        {
            _enderecosappservice = enderecosappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}