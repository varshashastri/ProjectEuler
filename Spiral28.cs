using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
public class ProjectEuler
{
    static int findNextSpiralDiagonalValue(int aiminus1, int i)
    {
        return aiminus1 + (i - 1) * 8 + 2;
    }
    static void diagonalsum(int spiralsize)
    {
        int ai = 1;
        int sum = ai;
        for (int i = 1; i <= (spiralsize - 1) / 2; i++)
        {
            ai = findNextSpiralDiagonalValue(ai, i);
            sum += 4 * ai + 12 * i;
        }
        Console.WriteLine(sum);
    }
    public static void Main()
    {
        diagonalsum(1001);
    }
}