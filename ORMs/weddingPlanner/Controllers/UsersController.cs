using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using weddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
namespace weddingPlanner.Controllers
{
    public class UsersController : Controller
    {
        private PlannerContext _context;
        public UsersController(PlannerContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModels model)
        {
            if(ModelState.IsValid)
            {
                User exists = _context.Users.SingleOrDefault(u => u.Email == model.Reg.Email);
                if(exists != null)
                {
                    ModelState.AddModelError("Reg.Email", "This is email is already registered!");
                    return View("Index");
                }
                PasswordHasher<UserViewModels> hasher = new PasswordHasher<UserViewModels>();
                string hashed = hasher.HashPassword(model, model.Reg.Password);
                User newUser = new User
                {
                    FirstName = model.Reg.FirstName,
                    LastName = model.Reg.LastName,
                    Email = model.Reg.Email,
                    Password = hashed
                };
                _context.Add(newUser);
                _context.SaveChanges();
                int id = _context.Users.Where(u => u.Email == model.Reg.Email).Select(u => u.UserId).SingleOrDefault();
                HttpContext.Session.SetInt32("id", id);
                return RedirectToAction("Home", "Weddings");
            }
            return View("Index");   
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserViewModels model)
        {
            if(ModelState.IsValid)
            {
                User exists = _context.Users.SingleOrDefault(u => u.Email == model.Login.Email);
                if(exists == null)
                {
                    ModelState.AddModelError("Login.Email", "Email not found");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                
                if(hasher.VerifyHashedPassword(exists, exists.Password, model.Login.Password) == 0)
                {
                    ModelState.AddModelError("Login.Password", "Incorrect password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("id", exists.UserId);
                return RedirectToAction("Home", "Weddings");
            }
            return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
