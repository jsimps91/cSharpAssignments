using System;
using System.ComponentModel.DataAnnotations;
namespace bankAccounts.Models
{
    public abstract class BaseEntity{};

    public class Register : BaseEntity
    {
        public int UserId{get;set;}

        [Required]
        [MinLength(2)]
        public string FirstName{get;set;}

        [Required]
        [MinLength(2)]
        public string LastName{get;set;}

        [Required]
        [EmailAddress]
        public string Email{get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{get;set;}

    }

    public class Login : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8, ErrorMessage="Passwords must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
    }




}