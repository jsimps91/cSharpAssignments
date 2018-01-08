using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> things = new List<object>();
            things.Add(7);
            things.Add(28);
            things.Add(-1);
            things.Add(true);
            things.Add("chair");
            int sum = 0;
            foreach(var thing in things)
            {
                System.Console.WriteLine(thing);
                if(thing is int)
                {
                    sum += (int)thing;
                }
            }
            System.Console.WriteLine("sum is " + sum);
        }
    }
}
