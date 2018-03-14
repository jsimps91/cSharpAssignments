using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void print1to255()
        {
            for(int i = 1; i < 256; i++)
            {
                System.Console.WriteLine(i);
            }
        }
        static void printOdds()
        {
            for(int i = 1; i < 256; i+=2)
            {
                System.Console.WriteLine(i);
            }
        }
        static void printSum()
        {
            int sum = 0;
            for(int i = 0; i < 256; i ++)
            {
                sum += i;
                System.Console.WriteLine("Num is {0}, sum is {1}", i, sum);
            }
        }
        static void loop(int[] arr)
        {
            foreach(var i in arr)
            {
                System.Console.WriteLine(i);
            }
        }
        static void findMax(int[] arr)
        {
            int max = arr[0];
            for(int i = 1; i < arr.Length; i ++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                }
            }
            System.Console.WriteLine(max);
        }
        static void getAvg(int[] arr)
        {
            int sum = arr[0];
            int count = 1;
            for(int i = 1; i < arr.Length; i++)
            {
                count ++;
                sum += arr[i];
            }
            int avg = sum/count;
            System.Console.WriteLine(avg);
        }
        static void arrayWithOdds()
        {
            List<int> list = new List<int>();
            for(int i = 1; i < 256; i+=2)
            {
                list.Add(i);
            }
            System.Console.WriteLine(list.ToArray());
        }
        static void greaterThanY(int y, int[] arr)
        {
            int count = 0;
            for(int i = 0; i < arr.Length; i ++)
            {
                if(arr[i] > y)
                {
                    count++;
                }
            }
            System.Console.WriteLine(count);
        }
        static void squareVals(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] *= arr[i];
                System.Console.WriteLine(arr);
            }
        }
        static void zeroOutNegs(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    arr[i] = 0;
                }
                System.Console.WriteLine(arr[i]);
            }
        }
        static void minMaxAvg(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            int count = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] < min)
                {
                    min = arr[i];
                }
                else if(arr[i] > max)
                {
                    max = arr[i];
                }
                sum += arr[i];
                count ++;
            }
            float avg = (float)sum/(float)count;
            System.Console.WriteLine("Max is {0}", max);
            System.Console.WriteLine("Min is {0}", min);
            System.Console.WriteLine("Avg is {0}", avg);
        }
        static void shiftVals(int[] arr)
        {
            for(int i = 0; i < arr.Length-1; i ++)
            {
                arr[i] = arr[i + 1];
                System.Console.WriteLine(arr[i]);
            }
            arr[arr.Length-1] = 0;
            System.Console.WriteLine(arr[arr.Length-1]);
        }
        static void numToString(object[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] is int)
                {
                    if((int)arr[i] < 0)
                    {
                        arr[i] = "Dojo";
                    }
                }
                System.Console.WriteLine(arr[i]);
            }
        }
        


        static void Main(string[] args)
        {   
            int[] arr ={1,2,3,4,5};
            squareVals(arr);
            
        }
    }
}
