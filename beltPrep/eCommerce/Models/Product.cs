using System;
using System.ComponentModel.DataAnnotations;
namespace eCommerce.Models
{
    public class Product : BaseEntity
    {
        public int ProductId {get;set;}

        [Required(ErrorMessage="Please enter a product name")]
        
        public string Title {get;set;}

        [Required(ErrorMessage="Please enter an image url")]
        [DataType(DataType.ImageUrl)]
       
        public string ImageUrl{get;set;}

        [Required(ErrorMessage="Please enter a description")]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters long")]
        public string Description {get;set;}

        [Required(ErrorMessage="Please enter a quantity")]
        [Range(1,50, ErrorMessage = "Quantity must be between 1 and 50")]
        public int? Quantity {get;set;}

        [Required(ErrorMessage="Please enter a price!")]
        [DataType(DataType.Currency)]
        [Range(0.01, 10000.00, ErrorMessage="Price must be between $0.01 and $10,000")]
        public float? Price{get;set;}

        public Product()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}