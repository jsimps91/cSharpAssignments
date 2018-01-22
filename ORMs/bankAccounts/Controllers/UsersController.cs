using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
namespace bankAccounts.Controllers
{
    public class UsersController : Controller
    {
        private BankContext _context;
        public UsersController(BankContext context)
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
        [Route("createUser")]
        public  IActionResult createUser(Register regUser)
        {
            if(ModelState.IsValid)
            {
                User exists = _context.Users.SingleOrDefault(user => user.Email == regUser.Email);
                if(exists !=null)
                {
                    ModelState.AddModelError("Email", "An account with this email already exists!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<Register> Hasher = new PasswordHasher<Register>();
                    string hashed = Hasher.HashPassword(regUser, regUser.Password);
                    User newUser = new User
                    {
                        FirstName = regUser.FirstName,
                        LastName = regUser.LastName,
                        Email = regUser.Email,  
                        Password = hashed,
                        Balance = 0.00 
                    };
                    _context.Add(newUser);
                    _context.SaveChanges();
                    User user = _context.Users.Where(u => u.Email == regUser.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("userId", user.UserId);
                    HttpContext.Session.SetString("userName", user.FirstName);
                    return RedirectToAction("Home", "Accounts");
                }
                
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet]
        [Route("login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [Route("loginUser")]
        public IActionResult LoginUser(Login loginUser)
        {
            if(ModelState.IsValid)
            {
                User exists = _context.Users.Where(u => u.Email == loginUser.Email).SingleOrDefault();
                if(exists == null)
                {
                    ModelState.AddModelError("Email", "Email not found");
                    return View("LoginPage");
                }
                else
                {
                    var hasher = new PasswordHasher<User>();
                    if(hasher.VerifyHashedPassword(exists, exists.Password, loginUser.Password) == 0)
                    {
                        ModelState.AddModelError("Password", "Incorrect password");
                        return View("LoginPage");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userId", exists.UserId);
                        HttpContext.Session.SetString("userName", exists.FirstName);
                        return RedirectToAction("Home", "Accounts");
                    }
                }
            }
            else
            {
                return View("LoginPage");
            }
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
