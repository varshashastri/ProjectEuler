using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>
    /// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

    //1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

    //Let us list the factors of the first seven triangle numbers:

    // 1: 1
    // 3: 1,3
    // 6: 1,2,3,6
    //10: 1,2,5,10
    //15: 1,3,5,15
    //21: 1,3,7,21
    //28: 1,2,4,7,14,28
    //We can see that 28 is the first triangle number to have over five divisors.

    //What is the value of the first triangle number to have over five hundred divisors?
    /// </summary>
    class Class1
    {
        static int FindNumOfdivisorsofNumber(int num)
        {
            int total = 1;
            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                int power = 0;
                while (num % i == 0)
                {
                    num /= i;
                    power++;
                }
                total *= (power + 1);
            }
            return total * 2;
        }
        static void FindTriangleNumberWithAtOverNDivisors(int n)
        {
            int total = 0;
            int i = 0;
            while (total <= n)
            {
                i++;
                total = FindNumOfdivisorsofNumber((i * (i + 1) / 2));
            }
            Console.WriteLine(i * (i + 1) / 2);
        }
        public static void Main()
        {
            FindTriangleNumberWithAtOverNDivisors(500);
        }
    }
}
