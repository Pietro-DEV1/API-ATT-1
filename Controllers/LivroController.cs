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

    public class LivroController : ControllerBase
    {
       private static List<Livro> livros = new List<Livro>
       {
           new Livro {Id = 1, Nome = "Clean Code"},
           new Livro {Id = 2, Nome = "Dom Casmurro"},
           new Livro {Id = 3, Nome = "O Hobbit"}
       };

       [HttpGet("ObterLivros")]
        public ActionResult<List<Livro>> GetTodos()
        {
            return Ok(livros);
        }
    }
}