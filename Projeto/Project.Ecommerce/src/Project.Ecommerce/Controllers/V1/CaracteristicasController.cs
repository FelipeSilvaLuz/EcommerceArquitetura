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
    public class CaracteristicasController : BaseController
    {
        private readonly ICaracteristicaAppService _caracteristicaAppService;

        public CaracteristicasController(ICaracteristicaAppService caracteristicaAppService)
        {
            _caracteristicaAppService = caracteristicaAppService;
        }

        /// <summary>
        /// Incluir Caracteristica
        /// </summary>
        /// <remarks>
        /// # Incluir Caracteristica
        /// 
        /// Incluir uma Caracteristica na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Caracteristica
        ///     {
        ///         "IdProduto": 1,    
        ///         "Nome": "Teste nome",    
        ///         "Descricao": "Teste descrição",    
        ///         "Ordem": 1
        ///     }
        /// </remarks> 
        /// <param name="obj">Caracteristica</param>        
        /// <response code="200">Caracteristica incluida com sucesso</response>
        /// <response code="400">Caracteristica não encontrada</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Caracteristica obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_caracteristicaAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Caracteristica
        /// </summary>
        /// <remarks>
        /// # Consultar Caracteristica
        /// 
        /// Consulta uma Caracteristica na base de dados.
        /// </remarks>
        /// <param name="id">Id da Caracteristica</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma Caracteristica</response>
        /// <response code="400">Caracteristica não encontrado</response>
        [HttpGet("{id}", Name = "GetCaracteristica")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_caracteristicaAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Caracteristicas
        /// </summary>
        /// <remarks>
        /// # Listar Caracteristicas
        /// 
        /// Lista Caracteristicas da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Caracteristicas</response>
        /// <response code="400">Caracteristicas não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_caracteristicaAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Listar Caracteristicas por IdProduto
        /// </summary>
        /// <remarks>
        /// # Listar Caracteristicas por IdProduto
        /// 
        /// Lista Caracteristicas por IdProduto na base de dados.
        /// </remarks>
        /// <param name="idProduto">Listar por Id Produto</param> 
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Caracteristicas</response>
        /// <response code="400">Caracteristicas não encontrados</response>
        [HttpGet("{idProduto}", Name = "GetCaracteristicaPorIdProduto")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorIdProduto(int idProduto, bool getDependencies = false)
        {
            return Ok(_caracteristicaAppService.ListarPorIdProduto(idProduto, getDependencies));
        }

        /// <summary>
        /// Alterar Caracteristica
        /// </summary>
        /// <remarks>
        /// # Alterar Caracteristica
        /// 
        /// Altera uma Caracteristica na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Caracteristica
        ///     {
        ///         "id": 1,
        ///         "IdProduto": 1,    
        ///         "Nome": "Teste nome",    
        ///         "Descricao": "Teste descrição",    
        ///         "Ordem": 1
        ///     }
        /// </remarks> 
        /// <param name="obj">Caracteristica</param>        
        /// <response code="200">Caracteristica alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Caracteristica obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_caracteristicaAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Caracteristica
        /// </summary>
        /// <remarks>
        /// # Remover Caracteristica
        /// 
        /// Remove uma Caracteristica da base de dados.
        /// </remarks>
        /// <param name="id">Id da Caracteristica</param>        
        /// <response code="200">Caracteristica removido com sucesso</response>
        /// <response code="400">Caracteristica não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_caracteristicaAppService.Remover(id));
        }
    }
}