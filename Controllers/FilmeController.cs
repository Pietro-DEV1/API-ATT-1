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
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>
        {
            new Filme {Id = 1, Titulo = "Vingadores"},
            new Filme {Id = 2, Titulo = "Interestelar"},
            new Filme {Id = 3, Titulo = "Matrix"}
        };

        [HttpGet("ObterFilmes")]
        public ActionResult<List<Filme>> GetTodos()
        {
            return Ok(filmes);
        }
    }
}