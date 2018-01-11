using System;
namespace wizard2
{
    public class Wizard : Human
    {
        public Wizard(string n) : base(n)
        {
            health = 50;
            intelligence = 25;
        }
        public void heal()
        {
            health += 10*intelligence;
        }
        public void fireball(object x)
        {
            if(x is Human)
            {
              Human enemy = x as Human;
              Random rand = new Random();
              int damage = rand.Next(20,51);
              enemy.health -= damage;
              System.Console.WriteLine("{0} was attacked by {1}'s fireballs. Health is now {2}", enemy.name, name, enemy.health);  
            }
        }
        
    }
}