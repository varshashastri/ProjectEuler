using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    //  What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    class Program
    {
        static long[] primearr;
        static void findlistofprimes(double num)
        {
            long sq = Convert.ToInt64(Math.Sqrt(num));
            primearr = new long[sq];
            for (int i = 0; i < sq; i++)
            {
                primearr[i] = i;
            }
            primearr[1] = 0;
            for (int i = 2; i < sq; i++)
            {
                int k = 2;
                for (int j = i * k; j < sq; j = i * k)
                {
                    primearr[j] = 0;
                    k++;
                }
            }
            primearr = primearr.Distinct().ToArray();
        }

        static void LargestPrimeFactor(long num)
        {
            findlistofprimes(num);
            long max = 0;
            for (int i = 0; i < primearr.Length; i++)
            {
                if (primearr[i] != 0)
                {
                    long newnum = num % primearr[i];
                    if (newnum == 0 && primearr[i] > max)
                    {
                        max = primearr[i];
                    }
                }
            }
            if (max > 0)
                Console.WriteLine(max);
            else Console.WriteLine(num);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            LargestPrimeFactor(600851475143);
        }
    }
}
