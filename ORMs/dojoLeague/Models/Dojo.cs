using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace dojoLeague.Models
{
    public abstract class BaseEntity{}
    public class Dojo : BaseEntity
    {
        [Key]
        public int id {get;set;}

        [Required]
        public string name{get;set;}

        [Required]
        public string location {get;set;}

        [Required]
        public string info{get;set;}
        public ICollection<Ninja> ninjas { get; set; }


    }
}