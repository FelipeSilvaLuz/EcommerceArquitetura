using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Incluir Usuario
        /// </summary>
        /// <remarks>
        /// # Alterar Usuario
        /// 
        /// Incluir um Usuario na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Usuario
        ///     {
        ///         "Nome": "teste nome",    
        ///         "Perfil": "AD",    
        ///         "Email": "teste e-mail",    
        ///         "Senha": "teste senha"    
        ///     }
        /// </remarks> 
        /// <param name="obj">Usuario</param>        
        /// <response code="200">Usuario incluido com sucesso</response>
        /// <response code="400">Usuario não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Usuario obj)
        {
            return Ok(_usuarioAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Usuario
        /// </summary>
        /// <remarks>
        /// # Consultar Usuario
        /// 
        /// Consulta um Usuario na base de dados.
        /// </remarks>
        /// <param name="id">Id do Usuario</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Usuario</response>
        /// <response code="400">Usuario não encontrado</response>
        [HttpGet("{id}", Name = "GetUsuario")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_usuarioAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Usuarios
        /// </summary>
        /// <remarks>
        /// # Listar Usuarios
        /// 
        /// Lista Usuarios da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Usuarios</response>
        /// <response code="400">Usuarios não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_usuarioAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Usuario
        /// </summary>
        /// <remarks>
        /// # Alterar Usuario
        /// 
        /// Altera um Usuario na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Usuario
        ///     {
        ///         "id": 1,
        ///         "Nome": "teste nome",
        ///         "Perfil": "AD",  
        ///         "Email": "teste e-mail",    
        ///         "Senha": "teste senha"  
        ///     }
        /// </remarks> 
        /// <param name="obj">Usuario</param>        
        /// <response code="200">Usuario alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Usuario obj)
        {
            return Ok(_usuarioAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Usuario
        /// </summary>
        /// <remarks>
        /// # Remover Usuario
        /// 
        /// Remove um Usuario da base de dados.
        /// </remarks>
        /// <param name="id">Id do Usuario</param>        
        /// <response code="200">Usuario removido com sucesso</response>
        /// <response code="400">Usuario não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_usuarioAppService.Remover(id));
        }
    }
}