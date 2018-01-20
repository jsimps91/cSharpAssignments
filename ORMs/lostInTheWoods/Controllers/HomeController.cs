using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostInTheWoods.Models;
using lostInTheWoods.Factory;

namespace lostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.allTrails = trailFactory.FindAll();
            return View();
        }
        [HttpGet]
        [Route("addTrail")]
        public IActionResult AddTrail()
        {
            
            return View();
        }
        [HttpPost]
        [Route("createTrail")]
        public IActionResult createTrail(Trail trail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return View("addTrail");
        } 
        [HttpGet]
        [Route("trails/{id}")]  
        public IActionResult viewTrail(int id)
        {
            ViewBag.trail = trailFactory.FindByID(id);
            return View("Trail");
        }
    }
}
