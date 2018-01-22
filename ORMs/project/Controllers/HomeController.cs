using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using project.Models;

namespace project.Controllers
{
    public class HomeController : Controller
    {
           private PizzaContext _context;
 
    public HomeController(PizzaContext context)
    {
        _context = context;
    }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Pizza> AllUsers = _context.Pizzas.ToList();
            return View();
        }
    }
}
