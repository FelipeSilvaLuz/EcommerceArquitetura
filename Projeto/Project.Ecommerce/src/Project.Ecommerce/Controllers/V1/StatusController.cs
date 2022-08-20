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
    public class StatusController : BaseController
    {
        private readonly IStatusAppService _statusAppService;

        public StatusController(IStatusAppService statusAppService)
        {
            _statusAppService = statusAppService;
        }

        /// <summary>
        /// Incluir Status
        /// </summary>
        /// <remarks>
        /// # Incluir Status
        /// 
        /// Incluir um Status na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Status
        ///     {
        ///         "Nome": "teste nome",       
        ///         "Descricao": "teste descricao"    
        ///     }
        /// </remarks> 
        /// <param name="obj">Status</param>        
        /// <response code="200">Status incluido com sucesso</response>
        /// <response code="400">Status não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Status obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_statusAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Status
        /// </summary>
        /// <remarks>
        /// # Consultar Status
        /// 
        /// Consulta um Status na base de dados.
        /// </remarks>
        /// <param name="id">Id do Status</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Status</response>
        /// <response code="400">Status não encontrado</response>
        [HttpGet("{id}", Name = "GetStatus")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_statusAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Status
        /// </summary>
        /// <remarks>
        /// # Listar Status
        /// 
        /// Lista Status da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Status</response>
        /// <response code="400">Status não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_statusAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Status
        /// </summary>
        /// <remarks>
        /// # Alterar Status
        /// 
        /// Altera um Status na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Status
        ///     {
        ///         "id": 1,
        ///         "Nome": "teste nome",  
        ///         "Descricao": "teste descricao"   
        ///     }
        /// </remarks> 
        /// <param name="obj">Status</param>        
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Status obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_statusAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Status
        /// </summary>
        /// <remarks>
        /// # Remover Status
        /// 
        /// Remove um Status da base de dados.
        /// </remarks>
        /// <param name="id">Id do Status</param>        
        /// <response code="200">Status removido com sucesso</response>
        /// <response code="400">Status não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_statusAppService.Remover(id));
        }
    }
}