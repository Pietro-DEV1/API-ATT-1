using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        // Simulando banco em memória
        private static List<Aluno> alunos = new List<Aluno>
        {
            new Aluno { Id = 1, Nome = "João", Idade = 20 },
            new Aluno { Id = 2, Nome = "Maria", Idade = 22 },
            new Aluno { Id = 3, Nome = "Pedro", Idade = 21 }
        };

        // =========================
        // GET - LISTAR TODOS
        // =========================
        [HttpGet("ObterAlunos")]
        public ActionResult<List<Aluno>> GetTodos()
        {
            return Ok(alunos);
        }

        // =========================
        // GET - BUSCAR POR ID
        // =========================
        [HttpGet("ObterAlunoPorId/{id}")]
        public ActionResult<Aluno> GetPorId(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno);
        }

        // =========================
        // POST - CRIAR ALUNO
        // =========================
        [HttpPost("CriarAluno")]
        public ActionResult<Aluno> CriarAluno(Aluno novoAluno)
        {
            novoAluno.Id = alunos.Max(a => a.Id) + 1;

            alunos.Add(novoAluno);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoAluno.Id },
                novoAluno
            );
        }

        // =========================
        // PUT - ATUALIZAR ALUNO
        // =========================
        [HttpPut("AtualizarAluno/{id}")]
        public ActionResult AtualizarAluno(int id, Aluno alunoAtualizado)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            aluno.Nome = alunoAtualizado.Nome;
            aluno.Idade = alunoAtualizado.Idade;

            return Ok(aluno);
        }

        // =========================
        // DELETE - REMOVER ALUNO
        // =========================
        [HttpDelete("DeletarAluno/{id}")]
        public ActionResult DeletarAluno(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            alunos.Remove(aluno);

            return Ok("Aluno removido com sucesso.");
        }
    }
}