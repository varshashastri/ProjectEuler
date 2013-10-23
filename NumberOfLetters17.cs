using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace petrial
{
    class Program
    {
        static int FindNumOfLettersInNumber(int num)
        {
            int sum = 0;
            if (num == 1000) return 11;

            if (num / 10 == 0)
            {
                if (num == 1 || num == 2 || num == 6)
                    return 3;
                else if (num == 4 || num == 5 || num == 9)
                    return 4;
                else return 5;
            }
            else if (num / 100 == 0)
            {
                if (num % 10 == 0)
                {
                    if (num == 10) return 3;
                    else if (num == 20 || num == 30 || num == 80 || num == 90)
                    {
                        return 6;
                    }
                    else if (num == 40 || num == 50 || num == 60)
                    {
                        return 5;
                    }
                    else if (num == 70) return 7;
                }
                else if (num > 10 && num < 20)
                {
                    if (num == 11 || num == 12) return 6;
                    if (num == 15 || num == 16) return 7;
                    if (num == 17) return 9;
                    else return 8;
                }
                else
                {
                    return FindNumOfLettersInNumber(num % 10) + FindNumOfLettersInNumber((num / 10) * 10);
                }
            }
            else if (num / 1000 == 0)
            {
                sum += FindNumOfLettersInNumber((num / 100)) + 7;
                if (num % 100 != 0)
                {
                    sum += 3 + FindNumOfLettersInNumber(num % 100);
                }
                return sum;
            }

            return 0;
        }

        public static void Main()
        {
            long sum = 0;
            for (int i = 1; i <= 1000; i++)
                sum += FindNumOfLettersInNumber(i);
            Console.WriteLine(sum);
        }
    }
}
