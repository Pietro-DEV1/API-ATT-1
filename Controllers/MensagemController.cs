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
    public class MensagemController : ControllerBase
    {
       private static List<Mensagem> mensagens = new List<Mensagem>
       {
           new Mensagem {Id = 1, Conteudo = " Bem-vindo à API .NET 8."}
       };

        [HttpGet("ObterMensagens")]
        public ActionResult<List<Mensagem>> GetTodos()
        {
            return Ok(mensagens);
        }
    }
}