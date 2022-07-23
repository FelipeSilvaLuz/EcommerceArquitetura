using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class VendasController : Controller
    {
        private readonly IVendasAppService _vendasappservice;

        public VendasController(IVendasAppService vendasappservice)
        {
            _vendasappservice = vendasappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}