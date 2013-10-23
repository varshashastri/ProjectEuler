using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace petrial
{

    class Program
    {
        static void First10DigitsSumOFLargeNumbers()
        {
            int carry = 0;
            int currsum = 0;
            int[] ans = new int[50];
            int[,] list = new int[100, 50];
            StreamReader sr = new StreamReader(@"C:\Users\Varsha\Documents\Visual Studio 2010\Projects\projecteulerProblems\projecteuler\list.txt");
            for (int i = 0; i < 100; i++)
            {
                string s = sr.ReadLine();
                int j = 0;
                foreach (char c in s.ToCharArray())
                {
                    list[i, j] = c - '0';
                    j++;
                }
            }
            for (int i = 49; i >= 0; i--)
            {
                for (int j = 0; j < 100; j++)
                {
                    currsum += list[j, i];
                }
                currsum += carry;
                ans[i] = currsum % 10;
                carry = currsum / 10;
                currsum = 0;
            }
            Console.Write(carry);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(ans[i]);
            }
        }
        public static void Main()
        {
            First10DigitsSumOFLargeNumbers();

        }
    }
}
