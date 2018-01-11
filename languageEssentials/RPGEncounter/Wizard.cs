using System;

namespace wizard{
    public class Wizard : Human{

        public Wizard(string person) : base(person){
            intelligence = 25; 
            health = 50;
        }
        public void heal(){
            this.health += 10*this.intelligence;
            System.Console.WriteLine("health is now " + this.health);
        }
        public void fireball(Enemy enemy){
            Random rand = new Random();
            int hit = rand.Next(20,51);
            enemy.health -= hit;
            System.Console.WriteLine("{0}' was attacked by {1} health is now {2}", enemy.name, name, enemy.health);
        }
        public void listMethods(){
            System.Console.WriteLine("Your choices are 1)attack, 2)fireball, or 3)heal");
        }
    }
}