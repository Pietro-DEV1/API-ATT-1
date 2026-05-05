using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private static List<Time> times = new List<Time>
        {
            new Time {Id = 1, Nome = "Grêmio"},
            new Time {Id = 2, Nome = "Internacional"},
            new Time {Id = 3, Nome = "Juventude"}
        };

        private static int proximoId = 4;

        [HttpGet("ObterTimes")]
        public ActionResult<List<Time>> GetTodos()
        {
            return Ok(times);
        }

        [HttpGet("{id}")]
        public ActionResult<Time> GetPorId(int id)
        {
            var time = times.FirstOrDefault(t => t.Id == id);

            if (time == null)
                return NotFound("Time não encontrado");

            return Ok(time);
        }

        [HttpPost]
        public ActionResult<Time> Criar(Time novoTime)
        {
            novoTime.Id = proximoId++;
            times.Add(novoTime);

            return CreatedAtAction(nameof(GetPorId), new { id = novoTime.Id }, novoTime);
        }

        
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Time timeAtualizado)
        {
            var time = times.FirstOrDefault(t => t.Id == id);

            if (time == null)
                return NotFound("Time não encontrado");

            time.Nome = timeAtualizado.Nome;

            return Ok(time);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var time = times.FirstOrDefault(t => t.Id == id);

            if (time == null)
                return NotFound("Time não encontrado");

            times.Remove(time);

            return NoContent();
        }
    }
}