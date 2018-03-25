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
    public class CustomerController : Controller
    {
        private Context _context;

        public CustomerController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/customers")]
        public IActionResult Customers()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }
        [HttpPost]
        [Route("createCustomer")]
        public IActionResult createCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer existing = _context.Customers.SingleOrDefault(c => c.Name == customer.Name);
                if(existing == null)
                {
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Customers");
                }
            ModelState.AddModelError("Name", "This name is already registered");    
            ViewBag.Customers = _context.Customers.ToList();
            return View("Customers");
            }
            ViewBag.Customers = _context.Customers.ToList();
            return View("Customers");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            _context.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }
    }
}