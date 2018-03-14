using System.ComponentModel.DataAnnotations;
namespace demo.Models
{
    public abstract class BaseEntity{}
    public class Student : BaseEntity 
    {
        [Key]
        public int id {get;set;}

        public string name{get;set;}

        public int cohort_id{get;set;}
    }
}