using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace petrial
{

    class Program
    {
        static long NumberOfPathsGrid(int n, int currx, int curry)
        {
            if (currx == n)
                return 1;
            if (curry == n)
                return 1;
            return NumberOfPathsGrid(n, currx + 1, curry) + NumberOfPathsGrid(n, currx, curry + 1);
        }

        public static void Main()
        {
            Console.WriteLine(NumberOfPathsGrid(5, 0, 0));
        }
    }
}
