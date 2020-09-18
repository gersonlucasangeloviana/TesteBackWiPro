using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteBO clienteBO;
        public ClienteController(IClienteBO clienteBO)
        {
            this.clienteBO = clienteBO;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            try
            {
                var clienteCadastrado = await clienteBO.Cadastrar(cliente);
                return Ok(clienteCadastrado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
