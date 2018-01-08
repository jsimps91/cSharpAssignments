using System;
namespace wizard{
    public class Samurai : Human{
         public static int count = 0;
        public Samurai(string person) : base(person){
            health = 200;
            count ++;
        }
        public void deathBlow(Human enemy){
            if(enemy.health < 50)
            {
                enemy.health = 0;
                System.Console.WriteLine("{0} was attacked and health is now {1}", enemy.name, enemy.health);
            }
            else
            {
                System.Console.WriteLine("Enemy's health is greater than 50");
            }
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