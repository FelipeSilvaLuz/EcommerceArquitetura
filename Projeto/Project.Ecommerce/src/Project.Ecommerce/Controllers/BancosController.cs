using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class BancosController : Controller
    {
        private readonly IBancosAppService _bancosappservice;

        public BancosController(IBancosAppService bancosappservice)
        {
            _bancosappservice = bancosappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}