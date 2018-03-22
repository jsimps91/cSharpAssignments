using System.ComponentModel.DataAnnotations;
namespace weddingPlanner.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName{get;set;}
        [Required]
        [EmailAddress]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage="Please enter a valid email address")]
        public string Email{get;set;}

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long!")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        [Compare("Password", ErrorMessage="Passwords must match!")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage="Please enter a valid email address")]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

    }

    public class UserViewModels
    {
        public RegisterViewModel Reg {get;set;}
        public LoginViewModel Login {get;set;}
    }
}