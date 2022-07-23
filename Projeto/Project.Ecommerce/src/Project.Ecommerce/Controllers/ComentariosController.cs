using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly IComentarioAppService _comentarioAppService;

        public ComentariosController(IComentarioAppService comentarioAppService)
        {
            _comentarioAppService = comentarioAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}