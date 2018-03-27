using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using movieAPI.Models;
namespace movieAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("getMovieData/{search}")]
        public List<Movie> GetMovieData(string search)
        {
            var movies = new List<Movie>();
            WebRequest.getMovie(search, response => {
                movies = response;
            }).Wait();
            return movies;
        }

        // [HttpPost]
        // [Route("findMovie")]
        // public IActionResult FindMovie(string search)
        // {
        //     var movies = new List<Movie>();
        //     WebRequest.getMovie(search, response => {
        //         movies = response;
        //     }).Wait();
        //     ViewBag.Movies = movies;
        //     return View("Results");         
        // }
    }
}
