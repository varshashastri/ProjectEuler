using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

public class ProjectEuler
{
    static bool IsAbundant(int n)
    {
        int sum = 0;
        for (int i = 1; i < n; i++)
        {
            if (n % i == 0)
                sum += i;
        }
        if (sum > n) return true;
        return false;
    }
    static int[] GetAllAbundantNumbers(int n)
    {
        int[] list = new int[n];
        int x = 0;
        for (int i = 1; i < n; i++)
        {
            if (IsAbundant(i))
            {
                list[x] = i;
            }
            x++;
        }
        return list.Distinct().ToArray();
    }
    static int[] GetAllNumbersNotSumOf2Abundant(int n)
    {
        int[] listOfAllAbundantNumbers = GetAllAbundantNumbers(n);
        int[] NumbersSumOfTwoAbundantNumbers = new int[listOfAllAbundantNumbers.Length * listOfAllAbundantNumbers.Length];
        int len = listOfAllAbundantNumbers.Length;
        int x = 0;
        for (int i = 1; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                if (listOfAllAbundantNumbers[i] + listOfAllAbundantNumbers[j] < n)
                {
                    NumbersSumOfTwoAbundantNumbers[x] = listOfAllAbundantNumbers[i] + listOfAllAbundantNumbers[j];
                    x++;
                }
            }
        }
        NumbersSumOfTwoAbundantNumbers = NumbersSumOfTwoAbundantNumbers.Distinct().ToArray();
        return NumbersSumOfTwoAbundantNumbers;
    }
    static bool IsSumOf2Abundant(int n)
    {
        int[] arr = GetAllNumbersNotSumOf2Abundant(n);
        if (arr.Contains(n))
            return false;
        else return true;
    }
    static int GetRequiredSum(int n)
    {
        int sum = 0;

        int[] arr = GetAllNumbersNotSumOf2Abundant(n);
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return n * (n - 1) / 2 - sum;
    }
    public static void Main()
    {
        int n = 28123;
        Console.WriteLine(GetRequiredSum(n));
    }
}