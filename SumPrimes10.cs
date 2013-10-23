using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>
    //The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    //Find the sum of all the primes below two million.
    /// </summary>
    class Program
    {
        static long[] primearr;

        static void FindAllPrimes(long num)
        {
            primearr = new long[num];
            for (int i = 0; i < num; i++)
            {
                primearr[i] = i;
            }
            primearr[1] = 0;
            for (int i = 2; i < num; i++)
            {
                int k = 2;
                for (int j = i * k; j < num; j = i * k)
                {
                    primearr[j] = 0;
                    k++;
                }
            }
            primearr = primearr.Distinct().ToArray();

        }

        static void sumofprimes(long num)
        {
            long sum = 0;
            FindAllPrimes(num);
            for (int i = 0; i < primearr.Length; i++)
            {
                sum += primearr[i];
            }
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            sumofprimes(2000000);
        }
    }
}
