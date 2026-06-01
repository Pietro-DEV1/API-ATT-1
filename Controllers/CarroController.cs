using API_2.Data;
using API_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Carro/ObterCarros
        [HttpGet("ObterCarros")]
        public async Task<ActionResult<List<Carro>>> GetTodos()
        {
            return await _context.Carros.ToListAsync();
        }

        // GET: api/Carro/ObterCarroPorId/1
        [HttpGet("ObterCarroPorId/{id}")]
        public async Task<ActionResult<Carro>> GetPorId(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
                return NotFound("Carro não encontrado.");

            return carro;
        }

        // POST: api/Carro/CriarCarro
        [HttpPost("CriarCarro")]
        public async Task<ActionResult<Carro>> CriarCarro(Carro novoCarro)
        {
            _context.Carros.Add(novoCarro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoCarro.Id },
                novoCarro
            );
        }

        // PUT: api/Carro/AtualizarCarro/1
        [HttpPut("AtualizarCarro/{id}")]
        public async Task<ActionResult> AtualizarCarro(int id, Carro carroAtualizado)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
                return NotFound("Carro não encontrado.");

            carro.Marca = carroAtualizado.Marca;
            carro.Modelo = carroAtualizado.Modelo;

            await _context.SaveChangesAsync();

            return Ok(carro);
        }

        // DELETE: api/Carro/DeletarCarro/1
        [HttpDelete("DeletarCarro/{id}")]
        public async Task<ActionResult> DeletarCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
                return NotFound("Carro não encontrado.");

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return Ok("Carro removido com sucesso.");
        }
    }
}