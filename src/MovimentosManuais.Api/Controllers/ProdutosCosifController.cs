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
    public class ProdutosCosifController : Controller
    {
        private readonly IProdutoCosifService _produtoCosifService;
        private readonly ILogger _logger;

        public ProdutosCosifController(
          IProdutoCosifService produtoCosifService,
          ILogger<ProdutosCosifController> logger
            )
        {
            _produtoCosifService = produtoCosifService;
            _logger = logger;
        }

        /// <summary>
        /// Get Produtos Cosif
        /// </summary>
        /// <returns>Retorna todos os registros de produtos Cosif</returns>
        /// <response code="200">Retorna todos os registros</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Produto_Cosif> result = _produtoCosifService.ObterTodos();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new ErrorItem(2, "Erro interno"));
                }
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
        /// <returns>Busca de produtos Cosif por Cod</returns>
        /// <response code="200">Retorna os registros de produto Cosif de acordo com Cod</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByCod(string code)
        {
            try
            {
                var result = _produtoCosifService.ObterCod(code);
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
        /// <returns>Inserção de produtos Cosif na base</returns>
        /// <response code="200">Retorna registro cadastrado</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Produto_Cosif produto)
        {
            try
            {
                var result = _produtoCosifService.Adicionar(produto);
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
        /// <returns>Atualização de produtos Cosif na base</returns>
        /// <response code="200">Retorna registro atualizado</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Produto_Cosif produto)
        {
            try
            {
                _produtoCosifService.Atualizar(produto);
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
        /// <returns>Remoção de produtos Cosif na base</returns>
        /// <response code="200">Retorna Ok de registro removido</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] Produto_Cosif produto)
        {
            try
            {
                _produtoCosifService.Remover(produto);
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
