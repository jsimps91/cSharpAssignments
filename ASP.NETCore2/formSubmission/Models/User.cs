using System.ComponentModel.DataAnnotations;
 
namespace formSubmission.Models{
    public abstract class BaseEntity{}

    public class User : BaseEntity{
        [Required]
        [MinLength(4)]
        public string firstName {get;set;}
        [Required]
        [MinLength(4)]
        public string lastName{get;set;}
        [Required]
        [Range(0, int.MaxValue)]
        public int age{get;set;}
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }
}