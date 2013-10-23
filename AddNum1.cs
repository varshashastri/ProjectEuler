using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projecteuler
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    class Multipls3and5
    {
        public static int FindSum(int first, int last)
        {
            return (((last - first) / first) + 1) * (first + last) / 2;
        }
        static void Main(string[] args)
        {
            int multiplesof3, multiplesof5, multiplesof15;
            multiplesof3 = FindSum(3, 999);
            multiplesof5 = FindSum(5, 995);
            multiplesof15 = FindSum(15, 990);
            Console.WriteLine(multiplesof3 + multiplesof5 - multiplesof15);
            Console.ReadLine();
        }
    }
}