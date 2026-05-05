using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_2.Models;
using Microsoft.AspNetCore.Mvc; // 👈 ESSENCIAL

namespace API_2.Controllers
{
       [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario {Nome = "Thiago", Idade = 30}
        };


        [HttpGet("ObterUsuarios")]
        public ActionResult<List<Usuario>> GetTodos()
        {
            return Ok(usuarios);
        }
    }
}