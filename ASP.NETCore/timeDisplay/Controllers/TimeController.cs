using Microsoft.AspNetCore.Mvc;
using System;

namespace timeDisplay.Controllers{
    public class TimeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
    }
}