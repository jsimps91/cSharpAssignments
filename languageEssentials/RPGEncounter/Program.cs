using System;
using System.Collections.Generic;

namespace wizard
{
    class Program
    {
        public static void game(Wizard ally1, Ninja ally2, Samurai ally3, Zombie enemy1, Spider enemy2, Spider enemy3)
        {
            List<Human> allies = new List<Human>();
            allies.Add(ally1);
            allies.Add(ally2);
            allies.Add(ally3);
            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            List<object> players = new List<object>();
            players.Add(ally1);
            players.Add(enemy1);
            players.Add(ally2);
            players.Add(enemy2);
            players.Add(ally3);
            players.Add(enemy3);
            System.Console.WriteLine("**************************");
            System.Console.WriteLine($"Welcome to the game! We have {ally1.name}, {ally2.name}, and {ally3.name} in our ally party vs. {enemy1.name}, {enemy2.name} and {enemy3.name} in our enemy party");
            System.Console.WriteLine("**************************");

            while (players.Count > 3)
                {
            for (int idx = 0; idx < players.Count ; idx++)
            {
             
                    Random rand = new Random();
                    var player = players[idx];
                    if (player is Wizard)
                    {
                        System.Console.WriteLine($"{(player as Wizard).name} please select your attack method");
                        (player as Wizard).listMethods();
                        string method = Console.ReadLine();
                        Enemy enemyToAttack = enemies[rand.Next(0, enemies.Count)];
                        if (method == "2")
                        {
                            (player as Wizard).fireball(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                        else if(method == "3")
                        {
                            (player as Wizard).heal();
                        }
                        else
                        {
                            (player as Wizard).attack(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                        if (enemyToAttack.health <= 0)
                        {
                            System.Console.WriteLine($"{enemyToAttack.name} has been killed");
                            enemies.Remove(enemyToAttack);
                            players.Remove(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }

                    }
                    else if (player is Ninja)
                    {
                        System.Console.WriteLine($"{(player as Ninja).name} please select your attack method");
                        (player as Ninja).listMethods();
                        string method = Console.ReadLine();
                        Enemy enemyToAttack = enemies[rand.Next(0, enemies.Count)];
                        if (method == "2")
                        {
                            (player as Ninja).steal(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                        else
                        {
                            (player as Ninja).attack(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                        if (enemyToAttack.health <= 0)
                        {
                            System.Console.WriteLine($"{enemyToAttack.name} has been killed");
                            enemies.Remove(enemyToAttack);
                            players.Remove(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                    }
                    else if (player is Samurai)
                    {
                        System.Console.WriteLine($"{(player as Samurai).name} please select your attack method");
                        (player as Samurai).listMethods();
                        string method = Console.ReadLine();
                        Enemy enemyToAttack = enemies[rand.Next(0, enemies.Count)];
                        if (method == "2")
                        {
                            (player as Samurai).deathBlow(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                        else
                        {
                            (player as Samurai).attack(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                        if (enemyToAttack.health <= 0)
                        {
                            System.Console.WriteLine($"{enemyToAttack.name} has been killed");
                            enemies.Remove(enemyToAttack);
                            players.Remove(enemyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                    }
                    else
                    {
                        Human allyToAttack = allies[rand.Next(0, allies.Count)];
                        (player as Enemy).attack(allyToAttack);
                        System.Console.WriteLine("**************************");
                        if (allyToAttack.health <= 0)
                        {
                            System.Console.WriteLine($"{allyToAttack.name} has been killed");
                            allies.Remove(allyToAttack);
                            players.Remove(allyToAttack);
                            System.Console.WriteLine("**************************");
                        }
                    }


                }
            }
            System.Console.WriteLine("Game Over");
            if (allies.Count > enemies.Count)
            {
                System.Console.WriteLine("ALLIES WIN!");
            }
            else
            {
                System.Console.WriteLine("allies lose :( enemies win");
            }

        }
        static void Main(string[] args)
        {

            Wizard wizard1 = new Wizard("Gandalf");
            Human human1 = new Human("Bob");
            Ninja ninja1 = new Ninja("Ryu");
            Samurai samurai1 = new Samurai("Kousuke");
            Zombie zombie1 = new Zombie("Sally");
            Spider spider1 = new Spider("Aragog");
            Spider spider2 = new Spider("Charlotte");


            game(wizard1, ninja1, samurai1, zombie1, spider1, spider2);
        }
    }
}
