using System;
namespace eCommerce.Models
{
    public class Purchase : BaseEntity
    {
        public int PurchaseId {get;set;}
        public int CustomerId {get;set;}
        public Customer Customer {get;set;}
        public int ProductId {get;set;}
        public Product Product {get;set;}
        public int Quantity {get;set;}

        public Purchase()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        
    }
}