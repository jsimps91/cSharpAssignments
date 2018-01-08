using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [Route("projects")]
        [HttpGet]
        public IActionResult Projects()
        {
            return View();
        }

        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}