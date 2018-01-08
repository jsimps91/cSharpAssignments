using System;
namespace wizard{
    public class Enemy
    {
        public string name {get; set;}
        public int strength {get; set;}
        public int health {get; set;}
        public int intelligence {get; set;}
        public int dexterity {get; set;}
        public Enemy(string n)
        {
            name = n;
            strength = 10; 
            intelligence = 5;
            dexterity = 3;
            health = 75;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= strength * 5;
            }
        }
    }
}