using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?


    /// /// </summary>
    class Program
    {
        static int getlcmtilln(int n)
        {
            int x, lcm = 1;
            int[] arr = new int[n];
            for (int i = 1; i <= n; i++)
            {
                arr[i - 1] = i;
            }
            for (int i = 0; i < n; i++)
            {
                lcm *= arr[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] % arr[i] == 0)
                    {
                        arr[j] = arr[j] / arr[i];
                    }
                }
            }
            return lcm;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(getlcmtilln(20));
        }
    }
}
