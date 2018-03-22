using System.ComponentModel.DataAnnotations;
namespace lostInTheWoods.Models{
    public abstract class BaseEntity{}
    public class Trail : BaseEntity
    {
        [Required]
        public string name{get;set;}
        [Required]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters")]
        public string description{get;set;}

        [Required(ErrorMessage = "Length field is required")]
        public float? length {get;set;}
        [Required(ErrorMessage = "Elevation change field is required")]
        public int? elevationChange{get;set;}

        [Required(ErrorMessage = "Latitude field is required")]
       
        public double? lat{get;set;}

        [Required(ErrorMessage = "Longitude field is required")]
        public double? lon{get;set;}
        
        [Key]
        public int id{get;set;}

    }
}