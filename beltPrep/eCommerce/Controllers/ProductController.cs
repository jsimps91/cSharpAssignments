using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        public Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/products")]
        public IActionResult Products()
        {
            ViewBag.Products = _context.Products.Where(p => p.Quantity > 0).ToList();
            return View();
        }
        [HttpPost]
        [Route("createProduct")]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            ViewBag.Products = _context.Products.Where(p => p.Quantity > 0).ToList();
            return View("Products");
        }
        [HttpGet]
        [Route("getProductQuantity/{id}")]
        public int GetQuantity(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            return (int)product.Quantity;
        }
        [HttpGet]
        [Route("filterProducts/{filter}")]
        public List<Product> Filter(string filter)
        {
            filter = filter.ToLower();
            List<Product> Products = _context.Products.Where(p => p.Title.ToLower().Contains(filter) || p.Description.ToLower().Contains(filter)).ToList();
            return Products;
        }
        [HttpGet]
        [Route("filterProducts/")]
        public List<Product> Filter()
        {
            return _context.Products.Take(4).Where(p => p.Quantity > 0).ToList();
        }
        [HttpGet]
        [Route("showmore/{num}")]
        public List<dynamic> ShowMore(int num)
        {
            int amount = num * 4;
            List<dynamic> Results = new List<dynamic>();
            List<Product> One = _context.Products.Where(p => p.Quantity > 0).Take(amount).ToList();
            Results.Add(One);
            List<Product> Two = _context.Products.Where(p => p.Quantity > 0).ToList();
            Results.Add(Two.Count);
            return Results;
        }
    }
}