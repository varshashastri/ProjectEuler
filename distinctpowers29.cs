using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
public class ProjectEuler
{
    static Tuple<int, int> FactorizeGetNewAB(int a, int b)
    {
        int newa = a, newb = b;
        if (a % 2 == 0 || a % 3 == 0)
        {
            for (int i = 2; i < 7; i++)
            {
                if (Math.Pow(2, i) == a)
                {
                    newa = 2;
                    newb = i * b;
                    if (newb <= 100)
                        return new Tuple<int, int>(newa, newb);
                }
            }
            for (int i = 2; i < 5; i++)
            {
                if (Math.Pow(3, i) == a)
                {
                    newa = 2;
                    newb = i * b;
                    if (newb <= 100)
                        return new Tuple<int, int>(newa, newb);
                }
            }
            for (int i = 2; i < 4; i++)
            {
                if (Math.Pow(4, i) == a)
                {
                    newa = 2;
                    newb = i * b;
                    if (newb <= 100)
                        return new Tuple<int, int>(newa, newb);
                }
            }
        }
        for (int i = 5; i < 11; i++)
        {
            if (i * i == a)
            {
                newa = i;
                newb = i * b;
                return new Tuple<int, int>(newa, newb);
            }
        }
        return new Tuple<int, int>(newa, newb);
    }
    static void NumberOfDistinctPowers(int a, int b)
    {
        //int total=99*99;
        int count = 0;
        if (a > 100 || b > 100 || a < 2 || b < 2)
            Console.WriteLine("exceeds limits");
        else
        {
            for (int i = 2; i <= a; i++)
            {
                for (int j = 2; j <= b; j++)
                {
                    //22=4, 23=8, 24=16, 25=32
                    //32=9, 33=27, 34=81, 35=243
                    //42=16, 43=64, 44=256, 45=1024
                    //52=25, 53=125, 54=625, 55=3125
                    if (i == 32)
                    {

                    }
                    int newa = FactorizeGetNewAB(i, j).Item1;
                    int newb = FactorizeGetNewAB(i, j).Item2;
                    if (newa < i && newb <= b)
                    {
                        continue;
                    }
                    else
                        count++;
                }
            }
        }
        Console.WriteLine(count);
    }
    static string GetFactorizedBasePower(int a, int b, int n)
    {
        int num = a;
        int count = 0;
        int newa = a, newb = b;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            num = a;
            count = 0;
            while (num % i == 0)
            {
                num /= i;
                count++;
                if (num == 1)
                {
                    newa = i;
                    newb = count * b;
                    return newa + "," + newb;
                }
            }
        }
        return newa + "," + newb;
    }
    static void distinct()
    {
        string[] basepower = new string[10000];
        int index = 0;
        for (int i = 2; i <= 100; i++)
            for (int j = 2; j <= 100; j++)
            {
                string newone = GetFactorizedBasePower(i, j, 100);
                if (!basepower.Contains(newone))
                {
                    basepower[index++] = newone;
                }
            }
    }
    public static void Main()
    {
        distinct();
    }
}