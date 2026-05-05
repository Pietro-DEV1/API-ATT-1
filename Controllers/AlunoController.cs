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
    public class AlunoController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>
        {
            new Aluno {Id = 1, Nome = "João", Idade = 20},
            new Aluno {Id = 2, Nome = "Maria", Idade = 22},
            new Aluno {Id = 3, Nome = "Pedro", Idade = 21}
        };

        [HttpGet("ObterAlunos")]
        public ActionResult<List<Aluno>> GetTodos()
        {
            return Ok(alunos);
        }
    }
}