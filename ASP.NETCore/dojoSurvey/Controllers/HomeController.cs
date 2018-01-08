using Microsoft.AspNetCore.Mvc;

namespace dojoSurvey.Controllers
{
    public class HomeController : Controller 
    {
        [Route("")]
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        [Route("submitSurvey")]
        [HttpPost]
        public IActionResult Results(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View();
        }
    }
}