using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using theWall.Models;
using Microsoft.AspNetCore.Identity;

namespace theWall.Controllers
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
        public IActionResult Register(UserViewModels model)
        {
            if (ModelState.IsValid)
            {
                string checkEmail = $"SELECT * FROM users WHERE(email = '{model.Reg.email}')";
                var emailExists = DbConnector.Query(checkEmail);
                if (emailExists.Count == 0)
                {
                    PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
                    string hashed = hasher.HashPassword(model.Reg, model.Reg.password);
                    string query = $"INSERT INTO users(first_name, last_name, email, password, created_at, updated_at)VALUES('{model.Reg.firstName}', '{model.Reg.lastName}', '{model.Reg.email}', '{hashed}', NOW(), NOW())";
                    System.Console.WriteLine(query);
                    DbConnector.Execute(query);
                    HttpContext.Session.SetString("user", model.Reg.firstName);
                    var sessionQuery = DbConnector.Query(checkEmail);
                    int sessionId = (int)sessionQuery[0]["id"];
                    HttpContext.Session.SetInt32("id", sessionId);
                    return RedirectToAction("Wall", "Wall");
                }
                else
                {

                    ViewBag.email = "This email is already taken!";
                    return View("Index");
                }

            }
            else
            {
                ViewBag.email = "";
                return View("Index");
            }
        }

        [HttpPost]
        [Route("signin")]
                public IActionResult Signin(UserViewModels model)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE(email = '{model.Log.email}')";
                var exists = DbConnector.Query(query);
                if (exists.Count == 0)
                {
                    ViewBag.email = "Email not found";
                    return View("Index");
                }
                else
                {
                    string password = (exists[0]["password"]).ToString();
                    PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                    if (hasher.VerifyHashedPassword(model.Log, password, model.Log.password) == 0)
                    {
                        ViewBag.password = "Incorrect password!";
                        return View("Index");
                    }
                    else
                    {
                        int id = (int)exists[0]["id"];
                        HttpContext.Session.SetInt32("id", id);
                        string name = (exists[0]["first_name"]).ToString();
                        HttpContext.Session.SetString("user", name);
                        return RedirectToAction("Wall", "Wall");
                    }
                }
            }
            else
            {
                ViewBag.email = "";
                ViewBag.password = "";
                return View("Index");
            }
        }
    }
}


