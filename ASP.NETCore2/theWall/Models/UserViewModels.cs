using System.ComponentModel.DataAnnotations;
namespace theWall.Models{
    public abstract class BaseEntity {}
    public class RegUser : BaseEntity {
        [Required]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string firstName {get;set;}
        [Required]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="Last name can contain letters only")]
        public string lastName {get;set;}

        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password {get;set;}
        
        [Required]
       [Compare("password", ErrorMessage="Passwords must match!")]
        public string confirmPassword {get;set;}
    }

    public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }

    public class UserViewModels
    {
        public RegUser Reg{get;set;}
        public LoginUser Log{get;set;}
    }
}