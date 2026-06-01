using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_2.Models;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "IPhone 14", Preco = 3000 },
            new Produto { Id = 2, Nome = "Samsung Galaxy S22", Preco = 2000 },
            new Produto { Id = 3, Nome = "Google Pixel 6", Preco = 2000 }
        };

        [HttpGet("ObterProdutos")]
        public ActionResult<List<Produto>> GetTodos()
        {
            return Ok(produtos);
        }

        [HttpGet("ObterProdutoPorId/{id}")]
        public ActionResult<Produto> GetPorId(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        [HttpPost("CriarProduto")]
        public ActionResult<Produto> CriarProduto(Produto novoProduto)
        {
            novoProduto.Id = produtos.Max(p => p.Id) + 1;

            produtos.Add(novoProduto);

            return CreatedAtAction(
                nameof(GetPorId),
                new { id = novoProduto.Id },
                novoProduto
            );
        }

        [HttpPut("AtualizarProduto/{id}")]
        public ActionResult AtualizarProduto(int id, Produto produtoAtualizado)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;

            return Ok(produto);
        }


        [HttpDelete("DeletarProduto/{id}")]
        public ActionResult DeletarProduto(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            produtos.Remove(produto);

            return Ok("Produto removido com sucesso.");
        }
    }
}