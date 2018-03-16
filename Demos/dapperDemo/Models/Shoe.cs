using System.ComponentModel.DataAnnotations;
namespace dapperDemo.Models
{
    public abstract class BaseEntity{}

    public class Shoe : BaseEntity
    {
        [Key]
        public int Id {get;set;}
        public string Brand {get;set;}
        public string Style {get;set;}
        public int Size {get;set;}
    }
}