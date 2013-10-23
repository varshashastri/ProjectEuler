using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
public class ProjectEuler
{
    static int GetValue(string s)
    {
        int sum = 0;
        foreach (char c in s)
        {
            sum += c - '0' - 16;
        }
        return sum;
    }
    static bool IsAGreaterThanB(string a, string b)
    {
        int len1 = a.Length;
        int len2 = b.Length;
        int i = 0;
        for (i = 0; i < len1; i++)
        {
            if (i >= len2)
                return true;
            if (a[i] == b[i])
            {
                continue;
            }
            else
            {
                if (a[i] - '0' > b[i] - '0')
                {
                    return true;
                }
                else return false;
            }
        }
        if (i < len2) return false;
        return true;
    }
    static void FindValueOfAllStrings()
    {
        char[] sep = { ',' };
        int sum = 0;
        StreamReader sr = new StreamReader(@"C:\Users\Varsha\documents\visual studio 2010\Projects\projecteulerProblems\projecteuler\list.txt");
        String[] Names = sr.ReadLine().Split(sep);
        int[] value = new int[Names.Length];
        for (int i = 0; i < Names.Length; i++)
        {
            for (int j = i; j < Names.Length; j++)
            {
                if (IsAGreaterThanB(Names[i], Names[j]))
                {
                    string temp = Names[i];
                    Names[i] = Names[j];
                    Names[j] = temp;
                }
            }
        }
        for (int i = 0; i < Names.Length; i++)
        {
            value[i] = GetValue(Names[i]);
            sum += (i + 1) * value[i];
        }
        for (int i = 0; i < Names.Length; i++)
        {
            Console.Write(Names[i] + ",");
        }
    }
    public static void Main()
    {
        FindValueOfAllStrings();
    }
}