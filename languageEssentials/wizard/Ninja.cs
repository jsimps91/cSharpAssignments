using System;
namespace wizard{
   
    public class Ninja: Human{
       
        public Ninja(string person) : base(person){
            dexterity = 175;
        }
        public void steal(Human enemy){
            this.attack(enemy);
            this.health += 10;
            System.Console.WriteLine("{0} was attacked by {1} and now has {2} health points. {3} has health of {4}", enemy.name, this.name, enemy.health, this.name, this.health);
        }
        public void getAway(){
            this.health -= 15;
            System.Console.WriteLine("{0} got away! Health is now {1}", this.name, this.health);
        }
    }

}