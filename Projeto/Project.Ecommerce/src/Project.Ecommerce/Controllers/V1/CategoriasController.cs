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
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaAppService _categoriasAppService;

        public CategoriasController(ICategoriaAppService categoriasAppService)
        {
            _categoriasAppService = categoriasAppService;
        }

        /// <summary>
        /// Incluir Categoria
        /// </summary>
        /// <remarks>
        /// # Incluir Categoria
        /// 
        /// Incluir uma Categoria na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Categoria
        ///     {
        ///         "Nome": "Teste nome"
        ///     }
        /// </remarks> 
        /// <param name="obj">Categoria</param>        
        /// <response code="200">Categoria incluida com sucesso</response>
        /// <response code="400">Categoria não encontrada</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Categoria obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_categoriasAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Categoria
        /// </summary>
        /// <remarks>
        /// # Consultar Categoria
        /// 
        /// Consulta uma Categoria na base de dados.
        /// </remarks>
        /// <param name="id">Id da Categoria</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma Categoria</response>
        /// <response code="400">Categoria não encontrado</response>
        [HttpGet("{id}", Name = "GetCategoria")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_categoriasAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <remarks>
        /// # Listar Categorias
        /// 
        /// Lista Categorias da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Categorias</response>
        /// <response code="400">Categorias não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_categoriasAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Categoria
        /// </summary>
        /// <remarks>
        /// # Alterar Categoria
        /// 
        /// Altera uma Categoria na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Categoria
        ///     {
        ///         "id": 1,
        ///         "Nome": "Teste nome"
        ///     }
        /// </remarks> 
        /// <param name="obj">Categoria</param>        
        /// <response code="200">Categoria alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Categoria obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_categoriasAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Categoria
        /// </summary>
        /// <remarks>
        /// # Remover Categoria
        /// 
        /// Remove uma Categoria da base de dados.
        /// </remarks>
        /// <param name="id">Id da Categoria</param>        
        /// <response code="200">Categoria removido com sucesso</response>
        /// <response code="400">Categoria não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_categoriasAppService.Remover(id));
        }
    }
}