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
    public class VariacoesController : Controller
    {
        private readonly IVariacaoAppService _variacaoppservice;

        public VariacoesController(IVariacaoAppService variacaoAppService)
        {
            _variacaoppservice = variacaoAppService;
        }

        /// <summary>
        /// Incluir Variacao
        /// </summary>
        /// <remarks>
        /// # Incluir Variacao
        /// 
        /// Incluir uma Variacao na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Variacao
        ///     {
        ///         "IdCategoria": 1,    
        ///         "IdVariacao": 1,    
        ///         "Nome": "teste",    
        ///         "Descricao": "teste Complemento",    
        ///         "Quantidade": 2,    
        ///         "Valor": 0.0   
        ///     }
        /// </remarks> 
        /// <param name="obj">Variacao</param>        
        /// <response code="200">Variacao incluida com sucesso</response>
        /// <response code="400">Variacao não encontrada</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Variacao obj)
        {
            return Ok(_variacaoppservice.Incluir(obj));
        }

        /// <summary>
        /// Consultar Variacao
        /// </summary>
        /// <remarks>
        /// # Consultar Variacao
        /// 
        /// Consulta uma Variacao na base de dados.
        /// </remarks>
        /// <param name="id">Id da Variacao</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma Variacao</response>
        /// <response code="400">Variacao não encontrado</response>
        [HttpGet("{id}", Name = "GetVariacao")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_variacaoppservice.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Variacoes
        /// </summary>
        /// <remarks>
        /// # Listar Variacoes
        /// 
        /// Lista Variacoes da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Variacoes</response>
        /// <response code="400">Variacoes não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_variacaoppservice.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Variacao
        /// </summary>
        /// <remarks>
        /// # Alterar Variacao
        /// 
        /// Altera uma Variacao na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Variacao
        ///     {
        ///         "id": 1,
        ///         "IdCategoria": 1,    
        ///         "IdVariacao": 1,    
        ///         "Nome": "teste",    
        ///         "Descricao": "teste Complemento",    
        ///         "Quantidade": 2,    
        ///         "Valor": 0.0   
        ///     }
        /// </remarks> 
        /// <param name="obj">Variacao</param>        
        /// <response code="200">Variacao alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Variacao obj)
        {
            return Ok(_variacaoppservice.Alterar(obj));
        }

        /// <summary>
        /// Remover Variacao
        /// </summary>
        /// <remarks>
        /// # Remover Variacao
        /// 
        /// Remove uma Variacao da base de dados.
        /// </remarks>
        /// <param name="id">Id da Variacao</param>        
        /// <response code="200">Variacao removido com sucesso</response>
        /// <response code="400">Variacao não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_variacaoppservice.Remover(id));
        }
    }
}