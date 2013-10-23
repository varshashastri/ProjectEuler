using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ProjectEuler 
{
 static void LargestRecurringCycle()
        {
            int divisor = 7;
            int dividend = Convert.ToInt32(Math.Pow(10, Math.Floor(Math.Log10(divisor)) + 1));
            int initial = dividend;
            List<int> dividends = new List<int>();
            int reminder = -1;
            string value = "";
            int q = 0;
            int maxcount = 0;
            int maxnum = 0;
            for (int i = 1; i < 1000; i++)
            {
                dividends.Clear();
                value = "";
                reminder = -1;
                divisor = i;
                dividend = Convert.ToInt32(Math.Pow(10, Math.Floor(Math.Log10(divisor)) + 1));

                while (reminder != 0)
                {
                    dividends.Add(dividend);
                    reminder = dividend % divisor;
                    q = dividend / divisor;
                    dividend = Convert.ToInt32(Math.Pow(10, Math.Floor(Math.Log10(reminder)) + 1)) * reminder;
                    value += q;
                    if (dividends.Contains(dividend))
                    {
                        if (maxcount < value.Length)
                        {
                            maxcount = value.Length;
                            maxnum = divisor;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine(maxnum);
        }
 public static void Main()
 {
     LargestRecurringCycle();
 }
}