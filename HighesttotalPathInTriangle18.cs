using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace petrial
{
    class Program
    {
        static void PrintHighestPathTotal()
        {
            int length = 100;
            int[,] list = new int[length, length];
            StreamReader sr = new StreamReader(@"c:\users\inshastv\documents\visual studio 2010\Projects\projecteuler\projecteuler\list.txt");
            for (int i = 0; i < length; i++)
            {
                string n = sr.ReadLine();
                char[] sep = { ' ' };
                int j = 0;
                foreach (string a in n.Split(sep))
                {
                    list[i, j] = Convert.ToInt32(a);
                    j++;
                }
            }
            for (int i = length - 1; i > 0; i--)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (list[i, j] > list[i, j + 1])
                    {
                        list[i - 1, j] += list[i, j];
                    }
                    else
                    {
                        list[i - 1, j] += list[i, j + 1];
                    }
                }
            }
            Console.WriteLine(list[0, 0]);
        }

        public static void Main()
        {
            PrintHighestPathTotal();
        }
    }
}
