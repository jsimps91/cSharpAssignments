using System;

namespace wizard{
    public class Wizard : Human{

        public Wizard(string person) : base(person){
            intelligence = 50; 
            health = 25;
        }
        public void heal(){
            this.health += 10*this.intelligence;
            System.Console.WriteLine("health is now " + this.health);
        }
        public void fireball(Human enemy){
            Random rand = new Random();
            int hit = rand.Next(20,51);
            enemy.health -= hit;
            System.Console.WriteLine("{0}'s health is now {1}", enemy.name, enemy.health);
        }
    }
}