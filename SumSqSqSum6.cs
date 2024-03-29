using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>

    //The sum of the squares of the first ten natural numbers is,

    //12 + 22 + ... + 102 = 385
    //The square of the sum of the first ten natural numbers is,

    //(1 + 2 + ... + 10)2 = 552 = 3025
    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025  385 = 2640.

    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    class Program
    {
        static long diffbtwsumsq(int n)
        {
            long sqsum = 0, sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sqsum += i * i;
                sum += i;
            }
            return Math.Abs(sqsum - sum * sum);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(diffbtwsumsq(100));
        }
    }
}
