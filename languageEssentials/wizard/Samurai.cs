using System;
namespace wizard2
{
    public class Samurai : Human 
    {
        public static int count;
        public Samurai(string n) : base (n)
        {
            health = 200;
            count++;
            
        }
        public void deathBlow(Human enemy)
        {
            if(enemy.health < 50)
            {
                enemy.health = 0;
                System.Console.WriteLine("{0} was attacked by {1}, health is now {2}", enemy.name, name, enemy.health);
            }
        }
        public void meditate()
        {
            health = 200;
            System.Console.WriteLine("{0} meditated and is now healed! Health is {1}", name, health);
        }
        public static void howMany()
        {
            System.Console.WriteLine(count);
        }
    }
}