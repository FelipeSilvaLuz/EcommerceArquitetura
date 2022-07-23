using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly IComentariosAppService _comentariosappservice;

        public ComentariosController(IComentariosAppService comentariosappservice)
        {
            _comentariosappservice = comentariosappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}