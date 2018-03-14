using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace pokeInfo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult Index(int id)
        {
            var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObject;
            return View();
        }
    }
}
