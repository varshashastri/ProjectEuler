using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

public class ProjectEuler
{
    static void fib1000digits()
    {
        BigInteger a = 1, b = 1;
        BigInteger n = a + b;
        int count = 3;
        while (BigInteger.Log10(n) < 999)
        {
            a = b;
            b = n;
            n = a + b;
            count++;
        }
        Console.WriteLine(count);
    }
    public static void Main()
    {
        fib1000digits();
    }
}