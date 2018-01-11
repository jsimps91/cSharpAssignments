using System;
namespace wizard2
{

    public class Human
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
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
                System.Console.WriteLine("{0} was attacked by {1}, health is now {2}", enemy.name, name, enemy.health);
            }
        }
        public void chooseAttack(Human enemy)
        {
            System.Console.WriteLine("Please choose an attack method");
            System.Console.WriteLine("1)Kick 2)Slap");
            string choice = Console.ReadLine();
            if(choice == "1")
            {
                Kick(enemy);
            }
            else if(choice == "2")
            {
                intelligence += 1;
                System.Console.WriteLine("{0} just slapped {1} and got smarter. Intelligence is now {2}", name, enemy.name, intelligence);
            }
        }

        public void Kick(Human enemy)
        {
            enemy.health -= 20;
            System.Console.WriteLine("{0} was kicked by {1}, health is now {2}", enemy.name, name, enemy.health);
        }
    }
}