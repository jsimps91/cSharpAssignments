
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;


namespace ajaxRandomPasscode.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/generate")]
        public JsonResult Generate()
        {
            int? attempt = HttpContext.Session.GetInt32("attempt");
            if(attempt == null)
            {
                HttpContext.Session.SetInt32("attempt", 1);
            }
            else
            {
                attempt += 1;
                HttpContext.Session.SetInt32("attempt", (int)attempt);
            }
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string passcode = "";
            Random rand = new Random();
            for(int i = 1; i < 15; i++)
            {
                int x = rand.Next(0,36);
                passcode += chars[x];
            }
            var result = new 
            {
                pc = passcode,
                num = HttpContext.Session.GetInt32("attempt")
            };
            return Json(result);
        }

        [HttpGet]
        [Route("/clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}