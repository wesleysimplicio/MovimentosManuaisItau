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
    public class MovimentosManuaisController : Controller
    {

        private readonly IMovimentoManualService _movimentoManualService;
        private readonly ILogger _logger;

        public MovimentosManuaisController(
          IMovimentoManualService movimentoManualService,
          ILogger<MovimentosManuaisController> logger
            )
        {
            _movimentoManualService = movimentoManualService;
            _logger = logger;
        }

        /// <summary>
        /// Get movimento manuais
        /// </summary>
        /// <returns>Retorna todos os registros de movimento manuais</returns>
        /// <response code="200">Retorna todos os registros</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var result = _movimentoManualService.ObterTodos();
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
        /// Get movimento manuais By Cod
        /// </summary>
        /// <returns>Busca de movimento manuais por Cod</returns>
        /// <response code="200">Retorna os registros de movimentoManual de acordo com Cod</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByCod(string code)
        {
            try
            {
                var result = _movimentoManualService.ObterCod(code);
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
        /// Post movimento manuais
        /// </summary>
        /// <returns>Inserção de movimento manuais na base</returns>
        /// <response code="200">Retorna registro cadastrado</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Movimento_Manual movimentoManual)
        {
            try
            {
                var result = _movimentoManualService.Adicionar(movimentoManual);
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
        /// Put movimento manuais
        /// </summary>
        /// <returns>Atualização de movimento manuais na base</returns>
        /// <response code="200">Retorna registro atualizado</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Movimento_Manual movimentoManual)
        {
            try
            {
                _movimentoManualService.Atualizar(movimentoManual);
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
        /// Delete movimento manuais
        /// </summary>
        /// <returns>Remoção de movimento manuais na base</returns>
        /// <response code="200">Retorna registro removido</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] Movimento_Manual movimentoManual)
        {
            try
            {
                _movimentoManualService.Remover(movimentoManual);
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
