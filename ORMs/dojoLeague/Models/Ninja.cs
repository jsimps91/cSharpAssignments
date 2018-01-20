using System.ComponentModel.DataAnnotations;
namespace dojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int id {get;set;}

        [Required]
        public string name{get;set;}

        [Required(ErrorMessage="Level field is required")]
        public int? level{get;set;}

        public int dojo_id{get;set;}

        
        public string description{get;set;}
        public string dojo_name{get;set;}

    }
}