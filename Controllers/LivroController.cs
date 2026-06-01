using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        // Simulando banco em memória
        private static List<Livro> livros = new List<Livro>
        {
            new Livro { Id = 1, Nome = "Clean Code" },
            new Livro { Id = 2, Nome = "Dom Casmurro" },
            new Livro { Id = 3, Nome = "O Hobbit" }
        };

        [HttpGet("ObterLivros")]
        public ActionResult<List<Livro>> GetTodos()
        {
            return Ok(livros);
        }

        [HttpGet("ObterLivroPorId/{id}")]
        public ActionResult<Livro> GetPorId(int id)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
                return NotFound("Livro não encontrado.");

            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public ActionResult<Livro> CriarLivro(Livro novoLivro)
        {
            novoLivro.Id = livros.Max(l => l.Id) + 1;

            livros.Add(novoLivro);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoLivro.Id },
                novoLivro
            );
        }

        [HttpPut("AtualizarLivro/{id}")]
        public ActionResult AtualizarLivro(int id, Livro livroAtualizado)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
                return NotFound("Livro não encontrado.");

            livro.Nome = livroAtualizado.Nome;

            return Ok(livro);
        }
        
        [HttpDelete("DeletarLivro/{id}")]
        public ActionResult DeletarLivro(int id)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro == null)
                return NotFound("Livro não encontrado.");

            livros.Remove(livro);

            return Ok("Livro removido com sucesso.");
        }
    }
}