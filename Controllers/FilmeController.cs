using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        
        private static List<Filme> filmes = new List<Filme>
        {
            new Filme { Id = 1, Titulo = "Vingadores" },
            new Filme { Id = 2, Titulo = "Interestelar" },
            new Filme { Id = 3, Titulo = "Matrix" }
        };

        [HttpGet("ObterFilmes")]
        public ActionResult<List<Filme>> GetTodos()
        {
            return Ok(filmes);
        }

        [HttpGet("ObterFilmePorId/{id}")]
        public ActionResult<Filme> GetPorId(int id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound("Filme não encontrado.");

            return Ok(filme);
        }

        [HttpPost("CriarFilme")]
        public ActionResult<Filme> CriarFilme(Filme novoFilme)
        {
            novoFilme.Id = filmes.Max(f => f.Id) + 1;

            filmes.Add(novoFilme);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoFilme.Id },
                novoFilme
            );
        }

        [HttpPut("AtualizarFilme/{id}")]
        public ActionResult AtualizarFilme(int id, Filme filmeAtualizado)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound("Filme não encontrado.");

            filme.Titulo = filmeAtualizado.Titulo;

            return Ok(filme);
        }

        [HttpDelete("DeletarFilme/{id}")]
        public ActionResult DeletarFilme(int id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound("Filme não encontrado.");

            filmes.Remove(filme);

            return Ok("Filme removido com sucesso.");
        }
    }
}