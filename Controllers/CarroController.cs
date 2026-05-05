using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private static List<Carro> carros = new List<Carro>
        {
            new Carro {Id =1 , Marca = "Honda", Modelo = "Civic"},
            new Carro {Id =2 , Marca = "Ford", Modelo = "Ka"},
            new Carro {Id =3, Marca = "Fiat", Modelo = "Mobi"}
        };

        [HttpGet("ObterCarros")]
        public ActionResult<List<Carro>> GetTodos()
        {
            return Ok(carros);
        }
    }
}