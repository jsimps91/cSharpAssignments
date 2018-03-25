using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using Stripe;
namespace eCommerce.Controllers
{
    public class PurchaseController : Controller
    {
        private Context _context;

        public PurchaseController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Products = _context.Products.Where(p => p.Quantity > 0).Take(4);
            ViewBag.Orders = _context.Purchases.OrderByDescending(p => p.CreatedAt).Take(3).Include(p => p.Customer).Include(p => p.Product);
            ViewBag.Customers = _context.Customers.OrderByDescending(c => c.CreatedAt).Take(3).Include(c => c.Purchases);
            return View();
        }


        [HttpGet]
        [Route("/orders")]
        public IActionResult Orders()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Products = _context.Products.Where(p => p.Quantity > 0).ToList();
            ViewBag.Orders = _context.Purchases.Include(p => p.Customer).Include(p => p.Product).ToList();
            return View();
        }

        [HttpPost]
        [Route("makePurchase")]
        public IActionResult MakePurchase(Purchase purchase)
        {
            Product product = _context.Products.SingleOrDefault(p => p.ProductId == purchase.ProductId);
            Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == purchase.CustomerId);
            product.UpdatedAt = DateTime.Now;
            ViewBag.Purchase = purchase;
            ViewBag.Product = product;
            ViewBag.Price = product.Price * purchase.Quantity;
            ViewBag.Customer = customer;
            return View("Checkout");
        }
        [HttpPost]
        [Route("checkout")]
        public IActionResult Finalize(Purchase purchase)
        {
            _context.Add(purchase);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
        [HttpGet]
        [Route("cancel")]
        public IActionResult Cancel()
        {
            return RedirectToAction("Orders");
        }
    }   
}
