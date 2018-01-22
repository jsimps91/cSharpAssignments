namespace project.Models
{
    public abstract class BaseEntity{}
    public class Pizza : BaseEntity
    {
        public int PizzaId{get;set;}

        public string Type{get;set;}

        public string Topping{get;set;}
    }
}