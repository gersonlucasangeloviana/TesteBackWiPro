using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocacaoController : Controller
    {
        private readonly ILocacaoBO locacaoBO;
        public LocacaoController(ILocacaoBO locacaoBO)
        {
            this.locacaoBO = locacaoBO;
        }
        [HttpPost("alugar")]
        public async Task<IActionResult> Cadastrar(Locacao locacao)
        {
            try
            {
                var locacaoCadastrado = await locacaoBO.Cadastrar(locacao);
                return Ok(locacaoCadastrado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var lista = await locacaoBO.BuscarTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost("devolver")]
        public async Task<IActionResult> Devolver(int idLocacao)
        {
            try
            {
                var mensagemLocacao = await locacaoBO.Devolver(idLocacao);
                return Ok(mensagemLocacao);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
