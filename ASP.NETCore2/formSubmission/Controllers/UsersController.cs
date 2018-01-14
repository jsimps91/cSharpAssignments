using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using formSubmission.Models;

namespace formSubmission.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
   
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstName, string lastName, int age, string email, string password)
        {
            var user = new User{
                firstName = firstName,
                lastName = lastName, 
                age = age,
                email = email,
                password = password
            };
            if(TryValidateModel(user) == false){
                ViewBag.errors = ModelState.Values;
                return View("Errors");
            }

            return RedirectToAction("Success");
        }
        [HttpGet]
        [Route("Success")]
        public IActionResult Result()
        {
            return View();
        }
    }

}
