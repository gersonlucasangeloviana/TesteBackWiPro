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
    public class FilmeController : Controller
    {
        private readonly IFilmeBO filmeBO;
        public FilmeController(IFilmeBO filmeBO)
        {
            this.filmeBO = filmeBO;
        }
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(Filme filme)
        {
            try
            {
                var filmeCadastrado = await filmeBO.Cadastrar(filme);
                return Ok(filmeCadastrado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
