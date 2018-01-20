using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojoLeague.Factory;
using dojoLeague.Models;

namespace dojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;
        public DojoController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }
        [HttpGet]
        [Route("dojos")]
        public IActionResult AllDojos()
        {
            ViewBag.allDojos = dojoFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("createDojo")]
        public IActionResult createDojo(Dojo dojo)
        {
            if(ModelState.IsValid)
            {
                dojoFactory.Add(dojo);
                return RedirectToAction("AllDojos");
            }
            else
            {
                ViewBag.allDojos = dojoFactory.FindAll();
                return View("AllDojos");
            }
        }
        [HttpGet]
        [Route("dojo/{id}")]
        public IActionResult Dojo(int id)
        {
            ViewBag.dojo = dojoFactory.FindByID(id);
            ViewBag.dojoNinjas = ninjaFactory.FindByDojo(id);
            ViewBag.rogueNinjas = ninjaFactory.FindRogueNinjas();
            return View();
        }

        [HttpGet]
        [Route("banish/{id}/{dojo_id}")]
        public IActionResult Banish(int id, int dojo_id)
        {
            ninjaFactory.Banish(id);
            return Redirect($"/dojo/{dojo_id}");
        }

        [HttpGet]
        [Route("recruit/{id}/{dojo_id}")]
        public IActionResult Recruit(int id, int dojo_id)
        {
            ninjaFactory.Recruit(id, dojo_id);
            return Redirect($"/dojo/{dojo_id}");
        }
    }
}