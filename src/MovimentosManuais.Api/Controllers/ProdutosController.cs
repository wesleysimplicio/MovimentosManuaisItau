using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovimentosManuais.Api.Models;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ILogger _logger;

        public ProdutosController(
          IProdutoService produtoService,
          ILogger<ProdutosController> logger
            )
        {
            _produtoService = produtoService;
            _logger = logger;
        }

        /// <summary>
        /// Get Produtos
        /// </summary>
        /// <returns>Retorna todos os registros de produtos</returns>
        /// <response code="200">Retorna todos os registros</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var result = _produtoService.ObterTodos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível realizar a busca" : ex.Message;
                this._logger.LogError(ex, error);
                return BadRequest(new ErrorItem(1, error));
            }
        }
    }
}
