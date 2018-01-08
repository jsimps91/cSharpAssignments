using System;

namespace puzzles
{
    class Program
    {
        static void randomArray()
        {
            int sum = 0;
            int[] arr = new int[10];
            Random rand = new Random();
            for(int i = 0; i < 10; i++)
            {
                arr[i] = rand.Next(5,26);
                System.Console.WriteLine(arr[i]);
                sum += arr[i];
            }
            System.Console.WriteLine("sum is {0}", sum);
            int min = arr[0];
            int max = arr[0];
            foreach(int num in arr)
            {
                if(num < min)
                {
                    min = num;
                }
                else if(num > max)
                {
                    max = num;
                }
            }
            System.Console.WriteLine("min is {0}", min);
            System.Console.WriteLine("max is {0}", max);
        }
        static int coinToss()
        {
            System.Console.WriteLine("Tossing coin!");
            Random rand = new Random();
            int coin = rand.Next(1,3);
            if(coin == 1)
            {
                System.Console.WriteLine("tails");
            }
            else
            {
                System.Console.WriteLine("heads");
            }
            return coin;
        }
        static double mulitCoinToss(int num)
        {
            double result; 
            int heads = 0;
            int coin;
            Random rand = new Random();
            for(int i = 1; i < num; i++)
            {
                coin = rand.Next(1,3);
                System.Console.WriteLine(coin);
                if(coin == 2)
                {
                    heads++;
                }
            }
            result = (double)heads/(double)num;
            System.Console.WriteLine("result is {0}", result);
            return result;
        }
        static void names()
        {
            string[] arr = new string[]{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            int count = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Length > 5)
                {
                    count++;
                }
                int idx = rand.Next(0, arr.Length);
                string temp = arr[i];
                arr[i] = arr[idx];
                arr[idx] = temp;
            }
            string[] newArr = new string[count];
            int newIdx = 0;
            foreach(string name in arr)
            {
                if(name.Length > 5)
                {
                    newArr[newIdx] = name;
                    newIdx++;
                }
            }
            foreach(string name in newArr)
            {
                System.Console.WriteLine(name);
            }
        }
        static void Main(string[] args)
        {
            // randomArray();
            // coinToss();
            // mulitCoinToss(20);
            names();
        }
    }
}
