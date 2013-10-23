using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace petrial
{

    class Program
    {
        static int[] CollatzList;
        static int CollatzLength(long n)
        {
            int total = 0;
            if (n < CollatzList.Length)
            {
                if (CollatzList[n] > 0)
                {
                    return CollatzList[n];
                }
                else if (n == 1)
                {
                    CollatzList[n] = 1;
                }
                else if (n % 2 == 0)
                {
                    CollatzList[n] += CollatzLength(n / 2) + 1;
                }
                else
                {
                    CollatzList[n] += CollatzLength(3 * n + 1) + 1;
                }
                return CollatzList[n];
            }
            else
            {
                while (n >= CollatzList.Length)
                {
                    if (n % 2 == 0)
                    {
                        n /= 2;
                    }
                    else
                    {
                        n = 3 * n + 1;
                    }
                    total++;
                }
                return CollatzLength(n) + total;
            }
        }

        static void LongestCollatzSeqLessThanN(long n)
        {
            CollatzList = new int[n];
            CollatzList.Initialize();
            for (long i = 1; i < n; i++)
            {
                if (CollatzList[i] == 0)
                {
                    CollatzList[i] = CollatzLength(i);
                }
            }
            int max = 0, maxindex = 0;
            for (int i = 0; i < n; i++)
            {
                if (CollatzList[i] > max)
                {
                    max = CollatzList[i];
                    maxindex = i;
                }
            }
            Console.WriteLine(maxindex);
        }
        public static void Main()
        {
            LongestCollatzSeqLessThanN(1000000);
        }
    }
}
