using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace demo.Models
{
    public class Cohort : BaseEntity
    {
        [Key]
        public int id {get;set;}

        public string month{get;set;}

        public ICollection<Student> students {get;set;}

        public Cohort()
        {
           students = new List<Student>();
        }
    }
}