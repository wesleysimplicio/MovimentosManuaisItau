using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovimentosManuais.Api.Models;
using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
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

        /// <summary>
        /// Get Produtos By Cod
        /// </summary>
        /// <returns>Busca de produtos por Cod</returns>
        /// <response code="200">Retorna os registros de produto de acordo com Cod</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByCod(string code)
        {
            try
            {
                var result = _produtoService.ObterCod(code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível realizar a busca" : ex.Message;
                this._logger.LogError(ex, error);
                return BadRequest(new ErrorItem(1, error));
            }
        }

        /// <summary>
        /// Post Produtos
        /// </summary>
        /// <returns>Inserção de produtos na base</returns>
        /// <response code="200">Retorna registro cadastrado</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                var result = _produtoService.Adicionar(produto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível realizar a inserção" : ex.Message;
                this._logger.LogError(ex, error);
                return BadRequest(new ErrorItem(1, error));
            }
        }

        /// <summary>
        /// Put Produtos
        /// </summary>
        /// <returns>Atualização de produtos na base</returns>
        /// <response code="200">Retorna registro atualizado</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Produto produto)
        {
            try
            {
                 _produtoService.Atualizar(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível realizar a atualização" : ex.Message;
                this._logger.LogError(ex, error);
                return BadRequest(new ErrorItem(1, error));
            }
        }


        /// <summary>
        /// Delete Produtos
        /// </summary>
        /// <returns>Remoção de produtos na base</returns>
        /// <response code="200">Retorna registro removido</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] Produto produto)
        {
            try
            {
                _produtoService.Remover(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível realizar a remoção" : ex.Message;
                this._logger.LogError(ex, error);
                return BadRequest(new ErrorItem(1, error));
            }
        }

    }
}
