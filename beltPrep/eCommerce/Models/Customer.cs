using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace eCommerce.Models
{
    public class Customer : BaseEntity
    {
        public int CustomerId{get;set;}
        [Required]
        public string Name {get;set;}

        public List<Purchase> Purchases {get;set;}
        public Customer()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Purchases = new List<Purchase>();
        }
    }
}