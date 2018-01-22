using System;
using System.Collections.Generic;
namespace bankAccounts.Models
{
    public class User : BaseEntity
    {
        public int UserId{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public double Balance{get;set;}
        
        public List<Transaction> Transactions{get;set;}

        public User()
        {
            Transactions = new List<Transaction>();
        }
    }
}