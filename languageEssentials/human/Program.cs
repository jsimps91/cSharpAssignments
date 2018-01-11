using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Bob = new Human("Bob");
            Human Bill = new Human("Bill");
            Bob.attack(Bill);
            Bill.attack(5);
            Bill.attack(Bob);
            Human.howMany();
            System.Console.WriteLine(Bob);
            
            
         

            
        }
    }
}
