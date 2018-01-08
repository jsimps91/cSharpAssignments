using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("{first}/{last}/{age}/{color}")]
        public JsonResult Card(string first, string last, int age, string color)
        
        {
            var info = new 
            {
                FirstName = first,
                LastName = last,
                Age = age,
                FavColor = color
            };
            return Json(info);
        }
    }
}


