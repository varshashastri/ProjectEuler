using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>

    //A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,

    //a2 + b2 = c2
    //For example, 32 + 42 = 9 + 16 = 25 = 52.

    //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    //Find the product abc.
    /// </summary>
    class Program
    {
        static void pythsum1000()
        {
            for (int i = 1; i < 1000; i++)
            {
                for (int j = i; j < 1000; j++)
                {
                    int k = i * i + j * j;
                    double ks = Math.Sqrt(k);
                    if (ks - Math.Floor(ks) != 0)
                    {
                        continue;
                    }
                    if ((ks + i + j) == 1000)
                    {
                        Console.WriteLine(i * j * ks);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            pythsum1000();
        }
    }
}
