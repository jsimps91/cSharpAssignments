
using System;
namespace human
{
    public class Human 
    {
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public string name;

        public static int count = 0;

        public static void howMany()
        {
            System.Console.WriteLine(count);
        }
 
 
        public Human(string newName) 
        {
            name = newName;
            count++;
            
            
        }
        public Human(string n, int s, int i, int d, int h) 
        {
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }
        public object attack(object thing)
        {
            if(thing is Human)
            {
            Human enemy = thing as Human;
            int damage = this.strength*5;
            enemy.health -= damage;
            System.Console.WriteLine("{0} was attacked by {1} and lost {2} health points. Health is now {3}", enemy.name, this.name, damage, enemy.health);
            return (enemy as Human);
            }
            else{
                System.Console.WriteLine("Attack failed");
                return thing;
            }
            
        }
        public void sayName()
        {
            System.Console.WriteLine(name);
        }
    }
}