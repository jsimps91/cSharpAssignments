using System;
using System.Collections.Generic;
namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[] {0,1,2,3,4,5,6,7,8,9};
            string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            bool[] boolArray = new bool[10];
            for(int i = 0; i < 10; i ++)
            {
                if(i % 2 == 0)
                {
                    boolArray[i] = true;
                }
                else
                {
                    boolArray[i] = false;
                }
            }
            int[,] multiArray = new int[10,10];
            for(var i = 1; i < 11; i ++){
                for(int j = 1; j < 11; j ++)
                {;
                    multiArray[i-1,j-1] = i*j;
                    // System.Console.WriteLine(multiArray[i-1,j-1]);
                }
            }
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Pistachio");
            flavors.Add("Mint Chip");
            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            System.Console.WriteLine(flavors.Count);

            Dictionary<string,string> dict = new Dictionary<string,string>();
            foreach(string name in names)
            {
                dict.Add(name, null);
            }
            Random rand = new Random();
            foreach(string name in names)
            {
                dict[name] = flavors[rand.Next(0,flavors.Count)];
            }
            foreach(var entry in dict)
            {
                System.Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
