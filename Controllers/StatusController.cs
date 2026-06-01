using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private static List<Status> statustotal = new List<Status>
        {
            new Status
            {
                Id = 1,
                Mensagem = "API Online"
            }
        };

 
        [HttpGet("ObterStatus")]
        public ActionResult<List<Status>> GetTodos()
        {
            return Ok(statustotal);
        }

        [HttpGet("ObterStatusPorId/{id}")]
        public ActionResult<Status> GetPorId(int id)
        {
            var status = statustotal.FirstOrDefault(s => s.Id == id);

            if (status == null)
                return NotFound("Status não encontrado.");

            return Ok(status);
        }

        [HttpPost("CriarStatus")]
        public ActionResult<Status> CriarStatus(Status novoStatus)
        {
            novoStatus.Id = statustotal.Max(s => s.Id) + 1;

            statustotal.Add(novoStatus);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoStatus.Id },
                novoStatus
            );
        }

        [HttpPut("AtualizarStatus/{id}")]
        public ActionResult AtualizarStatus(int id, Status statusAtualizado)
        {
            var status = statustotal.FirstOrDefault(s => s.Id == id);

            if (status == null)
                return NotFound("Status não encontrado.");

            status.Mensagem = statusAtualizado.Mensagem;

            return Ok(status);
        }

        [HttpDelete("DeletarStatus/{id}")]
        public ActionResult DeletarStatus(int id)
        {
            var status = statustotal.FirstOrDefault(s => s.Id == id);

            if (status == null)
                return NotFound("Status não encontrado.");

            statustotal.Remove(status);

            return Ok("Status removido com sucesso.");
        }
    }
}