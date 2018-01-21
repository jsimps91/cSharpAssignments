using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewContext _context;
 
        public ReviewController(ReviewContext context)
    {
        _context = context;
    }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.Review.ToList();
            ViewBag.reviews = AllReviews;
            return View();
        }
        [HttpPost]
        [Route("createReview")]
        public IActionResult createReview(Review review)
        {
            if(ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                return View("Index");
            }
            
        }
    }
}
