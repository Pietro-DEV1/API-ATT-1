using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // 👈 ESSENCIAL
using API_2.Models; // 👈 IMPORTAR O MODEL

namespace API_2.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private static List<Cidade> cidades = new List<Cidade>
        {
            new Cidade {Id = 1, Nome = "Caxias do Sul"}
        };

        [HttpGet("ObterCidades")]
        public ActionResult<List<Cidade>> GetTodos()
        {
            return Ok(cidades);
        }
    }
}