using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace petrial
{
    class Program
    {
        static int[] NumOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static int DayOnNextMonth1st(int DayOnThisMonth1st, int NumberOfDaysInThisMonth)
        {
            return ((NumberOfDaysInThisMonth) % 7 + DayOnThisMonth1st) % 7;
        }
        static Boolean IsLeap(int year)
        {
            if ((year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0)))
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            int count = 0;
            int DayOnThisMonth1st = 5, NumberOfDaysInThisMonth = NumOfDays[0];
            for (int i = 1900; i <= 2000; i++)
            //for (int i = 2011; i <= 2012;i++ )
            {
                for (int j = 0; j < 12; j++)
                {
                    if (IsLeap(i) && j == 1)
                    {
                        NumberOfDaysInThisMonth = 29;
                    }
                    else
                    {
                        NumberOfDaysInThisMonth = NumOfDays[j];
                    }
                    if (i > 1900 && DayOnThisMonth1st == 6)
                    {
                        count++;
                    }
                    DayOnThisMonth1st = DayOnNextMonth1st(DayOnThisMonth1st, NumberOfDaysInThisMonth);
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
