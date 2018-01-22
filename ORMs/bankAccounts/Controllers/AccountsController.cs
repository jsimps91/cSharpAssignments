using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bankAccounts.Models;
using System.Linq;
namespace bankAccounts.Controllers
{
    public class AccountsController : Controller
    {
        private BankContext _context;
        public AccountsController(BankContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (id == null)
            {
                return RedirectToAction("LoginPage", "Users");
            }
            List<Transaction> Transactions = _context.Transactions.Where(t => t.UserId == id).ToList();
            TempData["userName"] = HttpContext.Session.GetString("userName");
            User loggedInUser = _context.Users.Where(u => u.UserId == id).SingleOrDefault();
            TempData["balance"] = loggedInUser.Balance;
            ViewBag.transactions = Transactions;
            return View();
        }

        [HttpPost]
        [Route("createTransaction")]
        public IActionResult CreateTransaction(double amount)
        {
            if (amount != 0)
            {
                int? id = HttpContext.Session.GetInt32("userId");
                if (id == null)
                {
                    return RedirectToAction("LoginPage", "Users");
                }
                Transaction newTransaction = new Transaction
                {
                    UserId = (int)id,
                    Amount = amount,
                    Date = DateTime.Now
                };
                User user = _context.Users.Where(u => u.UserId == newTransaction.UserId).SingleOrDefault();
                user.Balance += (double)newTransaction.Amount;
                _context.Add(newTransaction);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            else
            {
                return View("Home");
            }
        }
    }
}
