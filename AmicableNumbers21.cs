using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

public class ProjectEuler
{

    static int SumOfamicableNumbers(int n)
    {
        int sumret = 0;
        int[] ListOfSumOfDivisors = new int[n];
        ListOfSumOfDivisors.Initialize();
        for (int i = 1; i < n; i++)
        {
            int num = i;
            int SumOfDivisors = 0;
            for (int j = 1; j < i; j++)
            {
                if (num % j == 0)
                {
                    SumOfDivisors += j;
                }
            }
            ListOfSumOfDivisors[i] = SumOfDivisors;
            if (SumOfDivisors < n && ListOfSumOfDivisors[SumOfDivisors] < n && SumOfDivisors > 0 && ListOfSumOfDivisors[i] == SumOfDivisors && ListOfSumOfDivisors[SumOfDivisors] == i)
            {
                if (SumOfDivisors != ListOfSumOfDivisors[SumOfDivisors])
                {
                    sumret += SumOfDivisors + ListOfSumOfDivisors[SumOfDivisors];
                }
            }
        }
        return sumret;
    }
    public static void Main()
    {
        Console.WriteLine(SumOfamicableNumbers(10000));
    }
}