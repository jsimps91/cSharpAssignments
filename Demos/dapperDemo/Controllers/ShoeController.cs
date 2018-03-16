using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dapperDemo.Models;
using dapperDemo.Factory;

namespace dapperDemo.Controllers
{

    public class ShoeController : Controller
    {
        private readonly ShoeFactory shoeFactory;
        public ShoeController()
        {
            shoeFactory = new ShoeFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Shoes = shoeFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("addShoe")]
        public IActionResult AddShoe(Shoe newShoe)
        {
            shoeFactory.Add(newShoe);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult ViewShoe(int id)
        {
            ViewBag.Shoe = shoeFactory.FindByID(id);
            return View();
        }
    }
}
