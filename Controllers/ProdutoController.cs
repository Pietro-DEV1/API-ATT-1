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
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto {Id = 1, Nome = "IPhone 14", Preco = 3000},
            new Produto {Id = 2, Nome = "Samsung Galaxy S22", Preco = 2000},
            new Produto {Id = 3, Nome = "Google Pixel 6", Preco = 2000}
        };

        [HttpGet("ObterProdutos")]
        public ActionResult<List<Produto>> GetTodos()
        {
            return Ok(produtos);
        }
    }
}