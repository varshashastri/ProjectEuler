using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petrial
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.
    //Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    class Program
    {
        static bool IsPali(int num)
        {
            int n = num;
            int k = 1;
            while (n >= 1)
            {
                n /= 10;
                k *= 10;
            }
            k /= 10;
            int last = 10, first = k;
            int p, q;
            while (last <= first)
            {
                p = num / first;
                q = num % last;
                if (p % 10 == q / (last / 10))
                {
                    last *= 10;
                    first /= 10;
                }
                else
                {
                    return false;
                }
            }
            if (last > first)
                return true;
            else return false;
        }

        static void largestPalimul3()
        {
            int max = 0;
            for (int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    if (IsPali(i * j))
                    {
                        if (i * j > max)
                            max = i * j;
                    }
                }
            }
            Console.WriteLine(max);
        }

        static void Main(string[] args)
        {
            largestPalimul3();
        }
    }
}
