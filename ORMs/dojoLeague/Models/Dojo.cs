using System.ComponentModel.DataAnnotations;
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


    }
}