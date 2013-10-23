using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
public class ProjectEuler
{
    static long[] primearr;
    static void findlistofprimes(double num)
    {
        long sq = Convert.ToInt64(Math.Sqrt(num));
        primearr = new long[sq];
        for (int i = 0; i < sq; i++)
        {
            primearr[i] = i;
        }
        primearr[1] = 0;
        for (int i = 2; i < sq; i++)
        {
            int k = 2;
            for (int j = i * k; j < sq; j = i * k)
            {
                primearr[j] = 0;
                k++;
            }
        }
        primearr = primearr.Distinct().ToArray();
    }

    static void quadratic()
    {
        //n^2+an+b
        bool end = false;
        int maxcount = 0, maxa = 0, maxb = 0;
        findlistofprimes(10000000);
        int count = 0;
        for (int a = -999; a < 1000; a += 2)
        {
            for (int b = -999; b < 1000; b += 2)
            {
                int n = 0;
                end = false;
                count = 0;
                while (!end)
                {
                    if (primearr.Contains(n * n + a * n + b))
                    {
                        count++;
                    }
                    else
                    {
                        end = true;
                    }
                    n++;
                }
                if (count > maxcount)
                {
                    maxa = a;
                    maxb = b;
                    maxcount = count;
                }
            }
        }
        Console.WriteLine(maxa * maxb);
    }
    public static void Main()
    {
        quadratic();
    }
}