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
        [Route("")]
        public IActionResult Home()
        {
            return View("Index");
        }
 
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult Index(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
        {
            PokeInfo = ApiResponse;
        }
        ).Wait();
            return View();
        }
    }
}
