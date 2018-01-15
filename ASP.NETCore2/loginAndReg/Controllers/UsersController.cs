using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using loginAndReg.Models;
using DbConnection;

namespace loginAndReg.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.email = "";
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegUser model)
        {
            if (ModelState.IsValid)
            {
                string checkEmail = $"SELECT * FROM users WHERE(email = '{model.email}')";
                var emailExists = DbConnector.Query(checkEmail);
                if (emailExists.Count == 0)
                {
                    string query = $"INSERT INTO users(firstName, lastName, email, password)VALUES('{model.firstName}', '{model.lastName}', '{model.email}', '{model.password}')";
                    System.Console.WriteLine(query);
                    DbConnector.Execute(query);
                    HttpContext.Session.SetString("user", model.firstName);
                    var sessionQuery = DbConnector.Query(checkEmail);
                    int sessionId = (int)sessionQuery[0]["id"];
                    return RedirectToAction("Success");
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
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            string user = HttpContext.Session.GetString("user");
            ViewBag.user = user;
            return View();
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            ViewBag.email = "";
            ViewBag.password = "";
            return View();
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE(email = '{model.email}')";
                var exists = DbConnector.Query(query);
                if (exists.Count == 0)
                {
                    ViewBag.email = "Email not found";
                    return View("Login");
                }
                else
                {
                    string password = (exists[0]["password"]).ToString();
                    if (password != model.password)
                    {
                        ViewBag.password = "Incorrect password!";
                        return View("Login");
                    }
                    else
                    {
                        int id = (int)exists[0]["id"];
                        HttpContext.Session.SetInt32("id", id);
                        string name = (exists[0]["firstName"]).ToString();
                        HttpContext.Session.SetString("user", name);
                        return RedirectToAction("Success");
                    }
                }
            }
            else
            {
                ViewBag.email = "";
                ViewBag.password = "";
                return View("Login");
            }
        }
    }
}
