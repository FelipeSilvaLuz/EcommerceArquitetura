using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosAppService _usuariosAppService;

        public UsuariosController(IUsuarioAppService usuariosAppService)
        {
            _usuariosAppService = usuariosAppService;
        }

        [Route("/BuscarUsuario")]
        public IActionResult Listar()
        {
            var usuarios = _usuariosAppService.Listar();
            return View();
        }
    }
}
