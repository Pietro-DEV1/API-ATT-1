using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
       
        private static List<Cidade> cidades = new List<Cidade>
        {
            new Cidade
            {
                Id = 1,
                Nome = "Caxias do Sul"
            }
        };

        [HttpGet("ObterCidades")]
        public ActionResult<List<Cidade>> GetTodos()
        {
            return Ok(cidades);
        }

        [HttpGet("ObterCidadePorId/{id}")]
        public ActionResult<Cidade> GetPorId(int id)
        {
            var cidade = cidades.FirstOrDefault(c => c.Id == id);

            if (cidade == null)
                return NotFound("Cidade não encontrada.");

            return Ok(cidade);
        }

        [HttpPost("CriarCidade")]
        public ActionResult<Cidade> CriarCidade(Cidade novaCidade)
        {
            novaCidade.Id = cidades.Max(c => c.Id) + 1;

            cidades.Add(novaCidade);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novaCidade.Id },
                novaCidade
            );
        }

        [HttpPut("AtualizarCidade/{id}")]
        public ActionResult AtualizarCidade(int id, Cidade cidadeAtualizada)
        {
            var cidade = cidades.FirstOrDefault(c => c.Id == id);

            if (cidade == null)
                return NotFound("Cidade não encontrada.");

            cidade.Nome = cidadeAtualizada.Nome;

            return Ok(cidade);
        }

        [HttpDelete("DeletarCidade/{id}")]
        public ActionResult DeletarCidade(int id)
        {
            var cidade = cidades.FirstOrDefault(c => c.Id == id);

            if (cidade == null)
                return NotFound("Cidade não encontrada.");

            cidades.Remove(cidade);

            return Ok("Cidade removida com sucesso.");
        }
    }
}