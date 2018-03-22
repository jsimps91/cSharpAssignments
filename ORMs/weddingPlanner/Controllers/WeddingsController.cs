using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using weddingPlanner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace weddingPlanner.Controllers
{
    public class WeddingsController : Controller
    {
        private PlannerContext _context;

        public WeddingsController(PlannerContext context)
        {
            _context = context;
        }

        public int CheckSession()
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(id == null)
            {
                return 0;
            }
            return (int)id;
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index", "Users");
            }
            User loggedIn = _context.Users.SingleOrDefault(u => u.UserId == CheckSession());
            ViewBag.User = loggedIn;
            ViewBag.Weddings = _context.Weddings.Include(w => w.RSVPS).OrderBy(w => w.Date).ToList();
            return View();
        }
        [HttpGet]
        [Route("newWedding")]
        public IActionResult NewWedding()
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index", "Users");
            }
            return View();
        }
        [HttpPost]
        [Route("createWedding")]
        public IActionResult CreateWedding(Wedding wedding)
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index", "Users");
            }
            if(ModelState.IsValid)
            {
                if(wedding.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date must a future date");
                    return View("NewWedding");
                }
                wedding.UserId = CheckSession();
                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            return View("NewWedding");
        }
        [HttpGet]
        [Route("rsvp/{id}")]
        public IActionResult RSVP(int id)
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index", "Users");
            }
            RSVP rsvp = new RSVP
            {
                UserId = CheckSession(),
                WeddingId = id
            };
            _context.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("unrsvp/{id}")]
        public IActionResult UnRSVP(int id)
        {
            RSVP rsvp = _context.RSVPS.SingleOrDefault(r => r.UserId == CheckSession() && r.WeddingId == id);
            _context.Remove(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Wedding wedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == id);
            _context.Remove(wedding);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("weddings/{id}")]
        public IActionResult ShowWedding(int id)
        {
            ViewBag.Wedding = _context.Weddings.Include(w => w.RSVPS).ThenInclude(r => r.User).SingleOrDefault(w => w.WeddingId == id);
            return View();
        }
    }
}