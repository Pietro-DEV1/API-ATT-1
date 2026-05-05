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
    public class StatusController : ControllerBase
    {
       private static List<Status> statustotal = new List<Status>
       {
           new Status { Mensagem = "API Online" }
       };

         [HttpGet("ObterStatus")]
        public ActionResult<List<Status>> GetTodos()
        {
            return Ok(statustotal);
        }
    }
}