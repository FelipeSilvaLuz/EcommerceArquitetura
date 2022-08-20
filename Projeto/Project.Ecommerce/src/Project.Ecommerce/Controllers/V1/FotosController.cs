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
    public class FotosController : BaseController
    {
        private readonly IFotoAppService _fotoAppService;

        public FotosController(IFotoAppService fotoAppService)
        {
            _fotoAppService = fotoAppService;
        }

        /// <summary>
        /// Incluir Foto
        /// </summary>
        /// <remarks>
        /// # Alterar Foto
        /// 
        /// Incluir uma Foto na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Foto
        ///     {
        ///         "IdCategoria" : 1,
        ///         "IdProduto" : 1,
        ///         "Nome": "teste nome",
        ///         "Base64": ""
        ///     }
        /// </remarks> 
        /// <param name="obj">Foto</param>        
        /// <response code="200">Foto incluida com sucesso</response>
        /// <response code="400">Foto não encontrada</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Foto obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_fotoAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Foto
        /// </summary>
        /// <remarks>
        /// # Consultar Foto
        /// 
        /// Consulta uma Foto na base de dados.
        /// </remarks>
        /// <param name="id">Id da Foto</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma Foto</response>
        /// <response code="400">Foto não encontrado</response>
        [HttpGet("{id}", Name = "GetFoto")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_fotoAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Fotos
        /// </summary>
        /// <remarks>
        /// # Listar Fotos
        /// 
        /// Lista Fotos da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Fotos</response>
        /// <response code="400">Fotos não encontradas</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_fotoAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Foto
        /// </summary>
        /// <remarks>
        /// # Alterar Foto
        /// 
        /// Altera uma Foto na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Foto
        ///     {
        ///         "id": 1,
        ///         "IdCategoria" : 1,
        ///         "IdProduto" : 1,
        ///         "Nome": "teste nome",
        ///         "Base64": ""     
        ///     }
        /// </remarks> 
        /// <param name="obj">Foto</param>        
        /// <response code="200">Foto alterada com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Foto obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_fotoAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Foto
        /// </summary>
        /// <remarks>
        /// # Remover Foto
        /// 
        /// Remove uma Foto da base de dados.
        /// </remarks>
        /// <param name="id">Id da Foto</param>        
        /// <response code="200">Foto removido com sucesso</response>
        /// <response code="400">Foto não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_fotoAppService.Remover(id));
        }
    }
}