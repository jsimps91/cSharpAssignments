using System;
namespace wizard
{
    public class Zombie : Enemy 
    {
        public Zombie(string n) : base(n)
        {
            dexterity = 1;
            intelligence = 1;
            health = 50;
        }
    }
}