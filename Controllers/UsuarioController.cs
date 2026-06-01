using System;
using System.Collections.Generic;
using System.Linq;
using API_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        // Simulando banco em memória
        public static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Thiago", Idade = 30 }
        };

        [HttpGet("ObterUsuarios")]
        public ActionResult<List<Usuario>> GetTodos()
        {
            return Ok(usuarios);
        }

        [HttpGet("ObterUsuarioPorId/{id}")]
        public ActionResult<Usuario> GetPorId(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpPost("CriarUsuario")]
        public ActionResult<Usuario> CriarUsuario(Usuario novoUsuario)
        {
            novoUsuario.Id = usuarios.Max(u => u.Id) + 1;

            usuarios.Add(novoUsuario);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoUsuario.Id },
                novoUsuario
            );
        }

        [HttpPut("AtualizarUsuario/{id}")]
        public ActionResult AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Idade = usuarioAtualizado.Idade;

            return Ok(usuario);
        }
        
        [HttpDelete("DeletarUsuario/{id}")]
        public ActionResult DeletarUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            usuarios.Remove(usuario);

            return Ok("Usuário removido com sucesso.");
        }
    }
}