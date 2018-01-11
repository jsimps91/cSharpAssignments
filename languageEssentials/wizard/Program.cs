using System;

namespace wizard2
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Joe = new Human("Joe");
            Samurai Heath = new Samurai("Heath");
            Ninja Naruto = new Ninja("Naruto");
            Wizard Gandalf = new Wizard("Gandalf");
            Naruto.attack(Gandalf);
            Naruto.steal(Gandalf);
            Gandalf.fireball(Heath);
            Samurai.howMany();
            Joe.chooseAttack(Heath);
        }
    }
}
