using System;
namespace wizard{
    public class Samurai : Human{
         public static int count = 0;
        public Samurai(string person) : base(person){
            health = 200;
            count ++;
        }
        public void deathBlow(Enemy enemy){
            if(enemy.health < 50)
            {
                enemy.health = 0;
                System.Console.WriteLine("{0} was attacked by {1} and health is now {2}", enemy.name, name, enemy.health);
            }
            else
            {
                System.Console.WriteLine("Enemy's health is greater than 50");
            }
        }
        public void listMethods(){
            System.Console.WriteLine("Your choices are 1)attack and 2)deathBlow");
        }
        public void meditate(){
            this.health = 200;
            System.Console.WriteLine("Health is now restored to "+ this.health);
        }
        public void howMany(){
            System.Console.WriteLine("Number of samurais: "+ count);
        }
    }
}