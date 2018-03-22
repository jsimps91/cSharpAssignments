using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace bankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        public int TransactionId{get;set;}
        public int UserId{get;set;}

        public User user{get;set;}
        
        public double? Amount{get;set;}
        public DateTime Date{get;set;}
    }
}