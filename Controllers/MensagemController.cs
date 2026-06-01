using System;
using System.Collections.Generic;
using System.Linq;
using API_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MensagemController : ControllerBase
    {
     
        private static List<Mensagem> mensagens = new List<Mensagem>
        {
            new Mensagem
            {
                Id = 1,
                Conteudo = "Bem-vindo à API .NET 8."
            }
        };

        [HttpGet("ObterMensagens")]
        public ActionResult<List<Mensagem>> GetTodos()
        {
            return Ok(mensagens);
        }

        [HttpGet("ObterMensagemPorId/{id}")]
        public ActionResult<Mensagem> GetPorId(int id)
        {
            var mensagem = mensagens.FirstOrDefault(m => m.Id == id);

            if (mensagem == null)
                return NotFound("Mensagem não encontrada.");

            return Ok(mensagem);
        }

        [HttpPost("CriarMensagem")]
        public ActionResult<Mensagem> CriarMensagem(Mensagem novaMensagem)
        {
            novaMensagem.Id = mensagens.Max(m => m.Id) + 1;

            mensagens.Add(novaMensagem);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novaMensagem.Id },
                novaMensagem
            );
        }

        [HttpPut("AtualizarMensagem/{id}")]
        public ActionResult AtualizarMensagem(int id, Mensagem mensagemAtualizada)
        {
            var mensagem = mensagens.FirstOrDefault(m => m.Id == id);

            if (mensagem == null)
                return NotFound("Mensagem não encontrada.");

            mensagem.Conteudo = mensagemAtualizada.Conteudo;

            return Ok(mensagem);
        }

        [HttpDelete("DeletarMensagem/{id}")]
        public ActionResult DeletarMensagem(int id)
        {
            var mensagem = mensagens.FirstOrDefault(m => m.Id == id);

            if (mensagem == null)
                return NotFound("Mensagem não encontrada.");

            mensagens.Remove(mensagem);

            return Ok("Mensagem removida com sucesso.");
        }
    }
}