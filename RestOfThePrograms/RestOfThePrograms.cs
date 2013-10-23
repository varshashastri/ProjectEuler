using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Timers;
using System.Diagnostics;
namespace projecteuler
{
    class Program
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
        static void FindAllPrimes(long num)
        {
            primearr = new long[num];
            for (int i = 0; i < num; i++)
            {
                primearr[i] = i;
            }
            primearr[1] = 0;
            for (int i = 2; i < num; i++)
            {
                int k = 2;
                for (int j = i * k; j < num; j = i * k)
                {
                    primearr[j] = 0;
                    k++;
                }
            }
            primearr = primearr.Distinct().ToArray();

        }
        static int getProduct(int p, int q, char[] listchars)
        {
            int prod = 1;
            for (int i = p; i <= q; i++)
            {
                prod *= listchars[i] - '0';
            }
            return prod;
        }
        static void LargestProduct()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Varsha\Documents\Visual Studio 2010\Projects\projecteulerProblems\projecteuler\list.txt");
            string txt = reader.ReadToEnd();
            char[] listchars = txt.ToCharArray();
            int p = 0, q = 4;
            int product = getProduct(p, q, listchars);
            int max = product;
            for (int i = q; i < listchars.Length; i++)
            {
                product = getProduct(i - 4, i, listchars);
                if (product > max)
                    max = product;
            }
            Console.WriteLine(max);
        }

        static long DynamicProgSol(int n)
        {
            long[,] arr = new long[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                arr[i, 0] = 1;
                arr[0, i] = 1;
            }
            arr[0, 0] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    arr[i, j] = arr[i, j - 1] + arr[i - 1, j];
                }
            }
            return arr[n, n];
        }

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
                        Console.WriteLine(SumOfDivisors + " " + ListOfSumOfDivisors[SumOfDivisors]);
                    }
                }
            }
            return sumret;
        }
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
        static int[] MultiplyToLargeNumber(int[] LargeNumber, int NumToMultiply)
        {
            int carry = 0;
            for (int i = LargeNumber.Length - 1; i >= 0; i--)
            {
                int prod = LargeNumber[i] * NumToMultiply + carry;

                LargeNumber[i] = prod % 10;
                carry = prod / 10;
            }
            //Console.WriteLine(LargeNumber);
            return LargeNumber;
        }
        static void HundredFactorial()
        {
            int[] arr = new int[1000];
            Array.Clear(arr, 0, arr.Length);
            arr[arr.Length - 1] = 1;
            for (int i = 2; i <= 100; i++)
            {
                arr = MultiplyToLargeNumber(arr, i);
            }
            int sum = 0;
            int x = 0;
            while (arr[x] == 0) x++;
            while (x < arr.Length)
            {
                sum += arr[x];
                Console.Write(arr[x]);
                x++;
            }
            Console.WriteLine();
            Console.WriteLine(sum);
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
        static int GetValue(string s)
        {
            int sum = 0;
            foreach (char c in s)
            {
                sum += c - '0' - 16;
            }
            return sum;
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
        static Tuple<int, int>[] FindMulFactArray(int num)
        {
            List<Tuple<int, int>> t = new List<Tuple<int, int>>();
            while (num > 0)
            {
                t.Add(FindLeastFactAndMul(num));
                num = num - factfun(t.Last().Item1) * t.Last().Item2;
            }
            return t.ToArray();
        }
        //static void FindNthLexicographicOrder(int RemainingPermutations, int[] output, int outputlen, int[] RemainingDigitsInAscOrder)
        //{
        //    Tuple<int, int>[] t=FindMulFactArray(98);
        //    for (int i = 0; i < t.Length; i++)
        //    {
        //        if (i == t.Length)
        //        {
        //            if (t[i].Item2 == 1)
        //            {
        //                for(int j=0;j<)
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }
        //}
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
                        //Console.WriteLine(value);
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
                Console.WriteLine(count + " " + n);
            }
            //Console.WriteLine(count);
        }
        static int findNextSpiralDiagonalValue(int aiminus1, int i)
        {
            return aiminus1 + (i - 1) * 8 + 2;
        }
        static void testnarcissisticcube()
        {
            for (int i = 1; i < 10000; i++)
            {
                int num = i;
                double sum = 0;
                while (num > 0)
                {
                    sum += Math.Pow(num % 10, 3);
                    num = num / 10;
                }
                //if (sum == i)
                //{
                Console.WriteLine(i + "=" + sum);
                //}
            }
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
            if (a > 100 || b > 100 || a < 0 || b < 0)
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
        static void find(int a, int b, int c)
        {
            bool isdown = true;
            int i = a;
            int downval = b - a;
            int upval = a - 1;
            while (i <= c)
            {
                Console.WriteLine(i);

                if (isdown)
                {
                    i += downval * 2 + 1;
                    isdown = false;
                }
                else
                {
                    i += upval * 2 + 1;
                    isdown = true;
                }
            }
        }
        static void narcissisticsum()
        {
            long sum = 0;
            long[] arr = new long[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = Convert.ToInt64(Math.Pow(i, 4));
            }
            for (long j = 2; j < 9999999; j++)
            {
                long num = j;
                long sumoffifthccubes = 0;
                while (num != 0)
                {
                    sumoffifthccubes += arr[num % 10];
                    num /= 10;
                }
                if (sumoffifthccubes == j)
                    sum += sumoffifthccubes;
            }
            Console.WriteLine(sum);
        }
        //static int[] NextLexicographic()
        //{ }
        static void NumberChain(long n)
        {
            int[] chainend = new int[n];
            int[] sq = new int[10];
            for (int i = 0; i < 10; i++)
            {
                sq[i] = i * i;
            }
            long num = 0;
            for (long i = 1; i < n; i++)
            {
                num = i;
                while (num != 89 && num != 1)
                {
                    int sum = 0;
                    while (num != 0)
                    {
                        sum += sq[num % 10];
                        num /= 10;
                    }
                    num = sum;
                    if (chainend[num] == 89) num = 89;
                    else if (chainend[num] == 1) num = 1;
                }

                if (num == 89)
                {
                    chainend[i] = 89;
                }
                else
                {
                    chainend[i] = 1;
                }
            }
            int count = 0;
            for (long i = 0; i < n; i++)
            {
                if (chainend[i] == 89) count++;
            }
            Console.WriteLine(count);
        }
        static void pandigital()
        {
            List<long> products = new List<long>();
            int[] array = new int[9];
        }
        static void convergentfore(int n)
        {
            long[] arrval = new long[n];
            long numvalues = n / 3 + 1;
            BigInteger num = 0;
            BigInteger den = 0;
            arrval[0] = 2;
            arrval[1] = 1;
            int k = 1;
            for (long i = 1; i <= arrval.Length - 3; i += 3)
            {
                arrval[i] = 1;
                arrval[i + 1] = k * 2;
                arrval[i + 2] = 1;
                k++;
            }
            num = 1;
            den = arrval.Last();
            long curr = arrval.Length - 2;
            while (curr >= 0)
            {
                BigInteger newnum = den;
                den = arrval[curr] * den + num;
                num = newnum;
                curr--;
            }

            Console.WriteLine(den);
            BigInteger sum = 0;
            while (den != 0)
            {
                sum += den % 10;
                den /= 10;
            }
            Console.WriteLine(sum);
        }
        static long rotate(long num)
        {
            long next = 0;
            long rem = num % 10;
            next = num / 10;
            num = next;
            while (num != 0)
            {
                num /= 10;
                rem = rem * 10;
            }
            next += rem;
            return next;
        }
        static void CircularPrimes(int n)
        {
            FindAllPrimes(n);
            int count = 0;
            long eff = 0;
            for (int i = 1; i < primearr.Length; i++)
            {
                bool end = false;
                long num = primearr[i];
                long nextnum = num;
                if (num / 10 == 0) { count++; continue; }
                long test = num;
                while (test != 0)
                {
                    if (test % 2 == 0 || test % 5 == 0) { end = true; break; }
                    test /= 10;
                }
                while (!end)
                {
                    eff++;
                    nextnum = rotate(nextnum);
                    if (primearr.Contains(nextnum))
                    {
                        if (nextnum == num) { count++; end = true; }
                    }
                    else end = true;
                }
            }
            Console.WriteLine(count);
        }
        static int getclosest(int n, int[] newvalues)
        {
            if (newvalues.Contains(n)) return n;
            for (int i = 0; i < newvalues.Length - 1; i++)
            {
                if (newvalues[i] < n && newvalues[i + 1] > n)
                {
                    if (n - newvalues[i] <= newvalues[i + 1] - n)
                        return newvalues[i];
                    else
                        return newvalues[i + 1];
                }
            }
            return 1000;
        }
        static int getNumericValue(char roman)
        {
            char[] romanvalues = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            switch (roman)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }
        static int RomanToNumeric(string roman)
        {
            if (roman == "") return 0;
            char[] arr = roman.ToCharArray();
            int maxindex = 0;
            int value;
            int prev = 0, next = 0, curr = 0;
            if (arr.Length == 1) return getNumericValue(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if (getNumericValue(arr[maxindex]) < getNumericValue(arr[i]))
                    maxindex = i;
            }
            curr = getNumericValue(arr[maxindex]);
            if (maxindex < arr.Length - 1)
                next = RomanToNumeric(roman.Substring(maxindex + 1));

            if (maxindex > 0)
                prev = RomanToNumeric(roman.Substring(0, maxindex));
            return curr + next - prev;
        }
        static string ToRoman(int n)
        {
            char[] romanvalues = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] newvalues = { 1, 5, 10, 50, 100, 500, 1000 };
            string romanum;
            int closest;
            for (int i = 0; i < romanvalues.Length; i++)
            {
                if (newvalues[i] == n)
                    return romanvalues[i].ToString();
            }
            closest = getclosest(n, newvalues);
            romanum = ToRoman(closest);
            if (closest > n)
            {
                return ToRoman(closest - n) + romanum;
            }
            else
            {
                return romanum + ToRoman(n - closest);
            }
        }
        static void checkdiff()
        {
            int sum = 0;
            StreamReader sr = new StreamReader(@"C:\Users\Varsha\documents\visual studio 2010\Projects\projecteulerProblems\projecteuler\roman.txt");
            for (int i = 0; i < 1000; i++)
            {
                string roman = sr.ReadLine();
                int num = RomanToNumeric(roman);
                string newroman = ToRoman(num);
                sum += roman.Length - newroman.Length;
            }
            Console.WriteLine(sum);
        }
        static int testdiff(string roman)
        {
            int sum = 0;
            int num = RomanToNumeric(roman);
            string newroman = ToRoman(num);
            sum = roman.Length - newroman.Length;
            return newroman.Length;
        }
        static bool IsTriangle(int i, int j, double k)
        {
            if (i >= j + k || j >= i + k || k >= i + j)
                return false;
            else return true;
        }
        static void pythagorean(int n)
        {
            double[] sqarr = new double[1000];
            List<double> sums = new List<double>();
            for (int i = 1; i <= n; i++)
            {
                sqarr[i - 1] = i * i;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (i == 30 && j == 40)
                    { }
                    double k = Math.Sqrt(i * i + j * j);
                    if (sqarr.Contains(i * i + j * j))
                    {
                        if (IsTriangle(i, j, k) && (i + j + k) < 1000)
                        {
                            sums.Add(i + j + k);
                        }
                    }
                }
            }
            double[] allsum = sums.ToArray();
            Array.Sort(allsum);
            int iter = 0;
            int len = 0;
            int maxlen = 0;
            double maxsum = 0;
            while (iter < allsum.Length - 1)
            {
                len = 0;
                while (allsum[iter] == allsum[iter + 1])
                {
                    len++;
                    iter++;
                }
                if (len > maxlen)
                {
                    maxlen = len;
                    maxsum = allsum[iter];
                }
                iter++;
            }
            Console.Write(maxsum);
        }
        //input of 10 digit arr and a number
        static void GetNdigitPower(int NumberOfDigits, int[] NDigitArr, int b, int Power)
        {
            int carry = 0;
            NDigitArr[NDigitArr.Length - 1] = 1;

            for (int j = 0; j < Power; j++)
            {
                carry = 0;
                for (int i = NumberOfDigits - 1; i >= 0; i--)
                {
                    int x = b * NDigitArr[i] + carry;
                    NDigitArr[i] = (x) % 10;
                    carry = x / 10;
                }
                //for (int i = 0; i < NDigitArr.Length; i++)
                //{
                //    Console.Write(NDigitArr[i] + ",");
                //}
                //Console.WriteLine();
            }
        }
        static void NDigitSuminArr2(int[] arr1, int[] arr2)
        {
            int carry = 0;
            if (arr1.Length == arr2.Length)
            {
                for (int i = arr1.Length - 1; i >= 0; i--)
                {
                    int x = arr1[i] + arr2[i] + carry;
                    arr2[i] = (x) % 10;
                    carry = (x) / 10;
                }
            }
        }
        static void projecteuler48(int lastndigits, int sumtill)
        {
            int b = 1;
            int[] arr2 = new int[lastndigits];
            for (int i = 1; i <= sumtill; i++)
            {
                b = i;
                int[] arr = new int[lastndigits];
                GetNdigitPower(lastndigits, arr, b, i);
                NDigitSuminArr2(arr, arr2);
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();
        }
        static List<Tuple<int, int>> GetListOfFactMul(int truenum)
        {
            //int truenum = 0;
            List<Tuple<int, int>> listtuples = new List<Tuple<int, int>>();
            //int n=1;
            //for (int i = num.Length - 1; i >= 0; i++)
            //{
            //    truenum += num[i] * n;
            //    n *= 10;
            //}
            while (truenum > 0)
            {
                Tuple<int, int> t = FindLeastFactAndMul(truenum);
                listtuples.Add(t);
                truenum -= factfun(t.Item1) * t.Item2;
            }
            return listtuples;
        }
        static void lexperm(int[] remaining, int num, int[] output)
        {
            List<Tuple<int, int>> listtuples = GetListOfFactMul(num);
            if (listtuples.Count == 1)
            {
                if (listtuples[0].Item2 == 1)//if perfect factorial
                {
                    Array.Sort(remaining);
                    Array.Reverse(remaining, remaining.Length - listtuples[0].Item1, listtuples[0].Item1);
                    int i = 0;
                    while (i < output.Length && output[i] != -1)
                    {
                        i++;
                    }
                    if (i < output.Length)
                    {
                        for (int j = 0; j < remaining.Length; j++)
                        {
                            output[i++] = remaining[j];
                        }
                    }
                }
                else //multiple of perfect factorial
                {
                    int firstptr = remaining.Length - listtuples[0].Item1 - 1;
                    int secondptr = firstptr + listtuples[0].Item2 - 1;
                    int temp = remaining[firstptr];
                    remaining[firstptr] = remaining[secondptr];
                    remaining[secondptr] = temp;
                    int i = 0;
                    while (i < output.Length && output[i] != -1)
                    {
                        i++;
                    }
                    if (i < output.Length)
                    {
                        for (int j = 0; j <= firstptr; j++)
                        {
                            output[i++] = remaining[j];
                            remaining[j] = -1;
                        }
                    }
                    List<int> l = remaining.ToList();
                    l.RemoveAll(nr => nr == -1);
                    remaining = l.ToArray();
                    Array.Sort(remaining);
                    Array.Reverse(remaining);
                    for (int j = 0; j < remaining.Length; j++)
                    {
                        output[i++] = remaining[j];
                    }
                }
            }
            else
            {
                int numdigsaffected = listtuples[0].Item1 + 1;
                int i = 0;
                while (i < output.Length && output[i] != -1)
                {
                    i++;
                }
                if (i < output.Length)
                {
                    for (int j = 0; j < remaining.Length - numdigsaffected; j++)
                    {
                        output[i++] = remaining[j];
                        remaining[j] = -1;
                    }
                }
                List<int> l = remaining.ToList();
                l.RemoveAll(nr => nr == -1);
                remaining = l.ToArray();
                output[i] = remaining[listtuples[0].Item2];
                i++;
                remaining[listtuples[0].Item2] = -1;
                l = remaining.ToList();
                l.RemoveAll(nr => nr == -1);
                remaining = l.ToArray();
                Array.Sort(remaining);
                num -= factfun(listtuples[0].Item1) * listtuples[0].Item2;
                lexperm(remaining, num, output);
            }
        }
        static Tuple<int, int> FindLeastFactAndMul(int RemPer)
        {
            Tuple<int, int> factandmul;
            int i = 1;
            int fact = 1;
            while (fact <= RemPer)
            {
                i++;
                fact = fact * i;
            }
            fact = fact / i;
            i--;
            int j = 1;
            while (fact * j <= RemPer)
            {
                j++;
            }
            j--;
            factandmul = new Tuple<int, int>(i, j);
            return factandmul;
        }
        static int factfun(int num)
        {
            int f = 1;
            for (int i = 1; i <= num; i++)
            {
                f = f * i;
            }
            return f;
        }
        static long[] numtoarr4dig(long num)
        {
            int i = 3;
            long[] arr = new long[4];
            while (num > 0)
            {
                arr[i] = num % 10;
                num /= 10;
                i--;
            }
            return arr;
        }
        static bool areperms(long a, long b)
        {
            long[] arr1 = numtoarr4dig(a);
            long[] arr2 = numtoarr4dig(b);
            bool flag = false;
            for (int i = 0; i < 4; i++)
            {
                flag = false;
                for (int j = 0; j < 4; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        flag = true;
                        arr1[i] = arr2[j] = -1;
                        break;
                    }
                }
                if (flag == false)
                    return false;
            }
            return true;
        }
        static void findseq(List<long> l)
        {
            long diff = 0;
            l.Sort();
            for (int i = 0; i < l.Count - 1; i++)
            {
                for (int j = i + 1; j < l.Count; j++)
                {
                    diff = l[j] - l[i];
                    if (l.Contains(l[j] + diff))
                    {

                        Console.WriteLine(l[i] + " " + l[j] + " " + (l[j] + diff));
                    }
                }
            }
        }
        static void specialseq()
        {
            int a = 1000, b = 10000;
            FindAllPrimes(10000);
            primearr = Array.FindAll(primearr, nr => nr > 1000);
            bool flag = false;
            for (int i = 0; i < primearr.Length; i++)
            {

                if (primearr[i] == 0) continue;
                flag = false;
                List<long> perms = new List<long>();
                if (perms.Count > 0)
                { }
                for (int j = i + 1; j < primearr.Length; j++)
                {
                    if (areperms(primearr[i], primearr[j]))
                    {
                        flag = true;
                        perms.Add(primearr[j]);
                        primearr[j] = 0;
                    }
                }
                if (flag == true && perms.Count >= 2)
                {
                    perms.Add(primearr[i]);
                    primearr[i] = 0;
                    findseq(perms);
                    //for (int k = 0; k < perms.Count; k++)
                    //{
                    //    Console.Write(perms[k] + " ");
                    //}
                    //Console.WriteLine();
                }
            }
        }
        static bool IsCurious(long num, long[] factorials)
        {
            long sum = 0;
            long n = num;
            while (n > 0)
            {
                sum += factorials[n % 10];
                n = n / 10;
            }
            if (sum == num)
                return true;
            else
                return false;
        }
        static long[] GetFactorials(int n)
        {
            long[] fact = new long[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                fact[i] = factfun(i);
            }
            return fact;
        }
        static bool IsPalindrome(long num)
        {
            long rev = 0;
            long n = num;
            while (n > 0)
            {
                rev = rev * 10 + (n % 10);
                n /= 10;
            }
            if (rev == num)
                return true;
            return false;
        }
        static bool IsPalindrome(long[] num)
        {
            long[] rev = num.Reverse().ToArray();
            for (int i = 0; i < rev.Length; i++)
            {
                if (num[i] != rev[i])
                {
                    return false;
                }
            }
            return true;
        }
        static long[] ToBinary(long n)
        {
            long[] bin = new long[Convert.ToInt32(Math.Floor(Math.Log(n, 2))) + 1];
            int i = bin.Length - 1;
            while (n > 0)
            {
                bin[i] = n % 2;
                i--;
                n /= 2;
            }
            return bin;
        }

        static void palindromeinbothbases()
        {
            long sum = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if (IsPalindrome(i) && IsPalindrome(ToBinary(i)))
                {
                    sum += i;
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine(sum);
        }
        static long ArrayToNum(long[] arr)
        {
            long sum = 0;
            int mul = 10;
            for (long i = 0; i < arr.Length; i++)
            {
                sum = sum * mul + arr[i];
            }
            return sum;
        }
        static long ArrayToNum(int[] arr)
        {
            long sum = 0;
            int mul = 10;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum * mul + arr[i];
            }
            return sum;
        }
        static void highestpandigitalprime()
        {
            FindAllPrimes(10000000);
            for (int i = 5040; i >= 0; i--)
            {
                int[] rem = { 1, 2, 3, 4, 5, 6, 7 };
                int[] output = { -1, -1, -1, -1, -1, -1, -1 };
                lexperm(rem, i, output);
                long num = ArrayToNum(output);
                if (primearr.Contains(num))
                {
                    Console.WriteLine(num);
                    break;
                }
            }
        }
        static int countofdigs(long n)
        {
            return Convert.ToInt32(Math.Floor(Math.Log10(n))) + 1;
        }
        static long getdig(long num, int loc)
        {
            loc = countofdigs(num) - loc;
            long rem = 0;
            for (int i = 0; i < loc; i++)
            {
                rem = num % 10;
                num /= 10;
            }
            return rem;
        }
        static void mulirrationalpositions()
        {
            long prod = 1;
            long d = 0;
            long i = 1;
            for (long n = 1; n < 1000000; n *= 10)
            {
                while (d <= n)
                {
                    for (int j = 0; j < countofdigs(i); j++)
                    {
                        d++;
                        if (n == d)
                        {
                            prod *= getdig(i, j);
                        }
                    }
                    i++;
                }
            }
            Console.WriteLine(prod);
        }
        static bool IsTriangleNum(long num)
        {
            double x = (Math.Sqrt(1 + 8 * num) - 1) / 2;
            if (x != Math.Floor(x))
            {
                return false;
            }
            return true;
        }
        static bool IsPentNum(long num)
        {
            double x = (1 + Math.Sqrt(1 + 24 * num)) / 6;
            if (x != Math.Floor(x))
            {
                return false;
            }
            return true;
        }
        static bool IsHexNum(long num)
        {
            double x = (1 + Math.Sqrt(num * 8 + 1)) / 4;
            if (x != Math.Floor(x))
            {
                return false;
            }
            return true;
        }
        static int WordValue(string word)
        {
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                sum += word[i] - 64;
            }
            return sum;
        }
        static void numwordvalues()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Varsha\documents\visual studio 2010\Projects\projecteulerProblems\projecteuler\list.txt");
            char[] sep = { ',' };
            string[] words = sr.ReadLine().Split(sep);
            long count = 0;
            foreach (string word in words)
            {
                if (IsTriangleNum(WordValue(word)))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static int binsearchclosestsmall(long[] arr, long key)
        {
            int low = 0, high = arr.Length - 1, mid;
            while (low <= high)
            {
                mid = (low + high) / 2;

                if (arr[mid] <= key && arr[mid + 1] > key)
                    return mid;
                else if (arr[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
        static void smallestoddgoldbach()
        {
            FindAllPrimes(1000000);
            for (int i = 3; i < 1000000; i += 2)
            {
                if (!primearr.Contains(i))
                {
                    int index = binsearchclosestsmall(primearr, i);
                    long val = i;
                    int j;
                    for (j = index; j >= 0; j--)
                    {
                        val = i;
                        val -= primearr[j];
                        val /= 2;
                        if (Math.Sqrt(val) == Math.Floor(Math.Sqrt(val)))
                        {
                            break;
                        }
                    }
                    if (j < 0)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
            }
        }
        static long GetNum(int[] arr, int start, int length)
        {
            long num = 0;
            //int mul=10;
            for (int i = start; i < start + length; i++)
            {
                num = num * 10 + arr[i];
            }
            return num;
        }
        static bool IsPandigitalultiple(int[] arr)
        {
            long num1 = GetNum(arr, 0, 1);
            long num2 = GetNum(arr, 1, 4);
            long num3 = GetNum(arr, 5, 4);
            if (num1 * num2 == num3)
                return true;
            num1 = GetNum(arr, 0, 2);
            num2 = GetNum(arr, 2, 3);
            num3 = GetNum(arr, 5, 4);
            if (num1 * num2 == num3)
                return true;
            return false;
        }
        static void swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static void perm(int[] arr, int index, List<long> nums)
        {
            if (index == arr.Length - 1)
            {
                if (CheckPanProp(arr))
                {
                    long num = GetNum(arr, 0, 10);
                    Console.WriteLine(num);
                    nums.Add(num);
                    //int num = GetNum(arr, 5, 4);
                    //if (!nums.Contains(num))
                    //{
                    //    nums.Add(num);
                    //}
                }
            }
            else
            {
                for (int i = index; i < arr.Length; i++)
                {
                    swap(i, index, arr);
                    perm(arr, index + 1, nums);
                    swap(i, index, arr);
                }
            }
        }
        static bool ConcatCheckPandigital(int[] arr)
        {
            int len = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                len += Convert.ToInt32(Math.Floor(Math.Log10(arr[i]))) + 1;
            }
            if (len != 9)
                return false;
            for (int i = 1; i <= 9; i++)
            {
                bool flag = false;
                for (int j = 0; j < arr.Length; j++)
                {
                    int num = arr[j];
                    while (num > 0)
                    {
                        if (num % 10 == i)
                        {
                            flag = true;
                            break;
                        }
                        num /= 10;
                    }
                    if (flag == true) break;
                }
                if (flag == false)
                    return false;
            }
            return true;
        }
        static void ConcatenatedProductPandigital()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i <= 9999; i++)
            {
                nums.Clear();
                for (int n = 1; n <= 7; n++)
                {
                    nums.Add(i * n);
                    if (ConcatCheckPandigital(nums.ToArray()))
                    {
                        for (int j = 0; j < nums.Count; j++)
                            Console.Write(nums[j]);
                        Console.WriteLine();
                    }
                }
            }
        }
        static bool CheckPanProp(int[] arr)
        {
            int j = 0;
            int[] primes = { 2, 3, 5, 7, 11, 13, 17 };
            int i;
            for (i = 1; i <= 7; i++)
            {
                long num = GetNum(arr, i, 3);
                if (num % primes[j] != 0)
                    break;
                j++;
            }
            if (i == 8)
                return true;
            return false;
        }
        static void withoutoverlappingranges(int[] arr)
        {
            int min = 0;
            int max = 1;
            for (int i = 2; i < arr.Length; i += 2)
            {
                if (arr[i] < arr[max])
                {
                    if (arr[i + 1] <= arr[max])
                    {
                        arr[i] = -1;
                        arr[i + 1] = -1;
                    }
                    else
                    {
                        arr[max] = arr[i] = -1;
                        max = i + 1;
                    }
                }
                else
                {
                    min = i;
                    max = i + 1;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void GeneratePentagonalNumbers(int n, long[] arr)
        {
            for (int i = 1; i <= n; i++)
            {
                arr[i - 1] = i * (3 * i - 1) / 2;
            }
        }
        static int binsearch(long key, long[] arr)
        {
            int low = 0, high = arr.Length - 1, mid;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
        static void pentsumdiff()
        {
            int n = 10000;
            long[] arr = new long[n];
            GeneratePentagonalNumbers(n, arr);
            for (int i = 1; i < n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (i == 8)
                    { }
                    int index = binsearch(arr[i] - arr[j], arr);
                    if (index == -1)
                        continue;
                    else
                    {
                        if (arr.Contains(arr[j] - arr[index]))
                        {
                            Console.WriteLine(arr[j] - arr[index]);
                        }
                    }
                }
            }
        }
        static void GetTriPentHexNum()
        {
            for (long i = 1; i < 1000000; i++)
            {
                long j = i * (i + 1) / 2;
                if (IsPentNum(j) && IsHexNum(j))
                    Console.WriteLine(j);
            }
        }
        static long[] NumToArray(long num)
        {
            long[] arr = new long[Convert.ToInt32(Math.Floor(Math.Log10(num) + 1))];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = num % 10;
                num /= 10;
            }
            return arr;
        }
        static bool ContainsSameDigits(long num1, long num2)
        {
            long[] arr1 = NumToArray(num1);
            long[] arr2 = NumToArray(num2);
            int[] comparearr = new int[arr1.Length];
            bool flag = false;
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                flag = false;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        flag = true;
                        arr2[j] = -1;
                    }
                }
                if (flag == false)
                {
                    return false;
                }
            }
            return true;
        }
        static void SameDigs()
        {
            for (int i = 1; i < 1000000; i++)
            {
                bool flag = false;
                int j = 3;//3
                while (flag == false && j <= 6)//6
                {
                    flag = !ContainsSameDigits(i * 2, i * j);
                    if (j > 4)
                    { }
                    j++;
                }
                if (j > 6)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
        static BigInteger ReverseAndAdd(BigInteger x)
        {
            BigInteger revx = 0;
            BigInteger temp = x;
            while (temp > 0)
            {
                revx = revx * 10 + temp % 10;
                temp = temp / 10;
            }
            return revx + x;
        }
        static bool IsPalindrome(BigInteger x)
        {
            BigInteger revx = 0;
            BigInteger temp = x;
            while (temp > 0)
            {
                revx = revx * 10 + temp % 10;
                temp = temp / 10;
            }
            if (revx == x)
                return true;
            return false;
        }
        static bool IsLychrel(BigInteger n)
        {
            int iterations = 1;
            BigInteger next = ReverseAndAdd(n);
            while (iterations <= 50)
            {
                if (IsPalindrome(next))
                {
                    return true;
                }
                else
                {
                    next = ReverseAndAdd(next);
                    iterations++;
                }
            }
            return false;
        }
        static void GetAllConsidered(int n, int pos, int[] arr, List<int[]> all)
        {

            if (n == 1)
            {
                int prev = pos;
                for (int i = pos; i < arr.Length; i++)
                {
                    swap(i, prev, arr);
                    int[] newarr = new int[arr.Length];
                    arr.CopyTo(newarr, 0);
                    all.Add(newarr);
                    prev = i;
                }
            }
            else
            {
                for (int start = pos; start < arr.Length - n + 1; start++)
                {
                    for (int i = pos; i < start; i++)
                    {
                        arr[i] = 0;
                    }
                    for (int i = start; i < start + n; i++)
                    {
                        arr[i] = 1;
                    }
                    for (int i = start + n; i < arr.Length; i++)
                    {
                        arr[i] = 0;
                    }
                    int[] newarr = new int[arr.Length];
                    arr.CopyTo(newarr, 0);
                    all.Add(newarr);
                    GetAllConsidered(n - 1, start + 1, arr, all);
                }
            }
        }
        static long[] ToBinary(long n, int len)
        {
            long[] bin = new long[len];
            bin.Initialize();
            //new long[Convert.ToInt32(Math.Floor(Math.Log(n, 2))) + 1];
            int i = bin.Length - 1;
            while (n > 0)
            {
                bin[i] = n % 2;
                i--;
                n /= 2;
            }
            return bin;
        }
        static List<long[]> GetAllComb(int n)
        {
            List<long[]> l = new List<long[]>();
            for (int i = 1; i <= n; i++)
            {
                l.Add(ToBinary(i));
            }
            return l;
        }
        static long Replace(long[] arr, long num, int replacement)
        {
            long[] n = NumToArray(num);
            int j = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 1)
                {
                    n[n.Length - 1 - j] = replacement;
                }
                j++;
            }
            return ArrayToNum(n);
        }
        static void starstarcomb()
        {
            FindAllPrimes(1000000);
            int n = Convert.ToInt32(Math.Floor(Math.Log10(primearr[1]))) + 1;
            List<long[]> l = null;
            l = GetAllComb(Convert.ToInt32(Math.Pow(2, n)));
            for (int i = 6000; i < primearr.Length; i++)
            {
                //int i=0;
                primearr[i] = 121313;
                int next = Convert.ToInt32(Math.Floor(Math.Log10(primearr[i]))) + 1;
                if (next != n)
                {
                    l = GetAllComb(Convert.ToInt32(Math.Pow(2, next) - 1));
                }
                for (int k = 0; k < l.Count; k++)
                {
                    int count = 0;
                    List<long> thelist = new List<long>();
                    for (int j = 0; j < 10; j++)
                    {
                        long a = Replace(l[k], primearr[i], j);
                        if (primearr.Contains(a))
                        {
                            count++;
                            thelist.Add(a);
                        }
                        if (j == 2 && count < 1)
                        { break; }
                        if (count >= 8)
                        {
                            Console.WriteLine(primearr[i]);
                            break;
                        }
                    }
                }
            }
        }
        static void nonmersenne()
        {
            BigInteger b = new BigInteger();
            b = BigInteger.Pow(2, 7830457);
            b *= 28433;
            b += 1;
            for (int i = 0; i < 10; i++)
            {
                Console.Write(b % 10);
                b /= 10;
            }
        }
        static bool IssumOfDigitsEqual(BigInteger b, BigInteger num)
        {
            BigInteger sum = 0;
            while (b > 0)
            {
                sum += b % 10;
                b /= 10;
            }
            if (sum == num)
                return true;
            return false;
        }
        static void lessthan30()
        {
            int count = 0;
            for (int i = 2; i < 100; i++)
            {
                for (int j = 2; j < 100; j++)
                {
                    if (count == 30)
                        return;
                    BigInteger b = BigInteger.Pow(j, i);
                    if (IssumOfDigitsEqual(b, j))
                    {
                        count++;
                        Console.WriteLine(b);
                    }
                }
            }
        }
        static void maximumdigitalsum()
        {

        }
        static void Main(string[] args)
        {
            //maximumdigitalsum();
            //nonmersenne();
            //int[] arr = new int[5];
            //List<int[]> l=new List<int[]>();
            //GetAllConsidered(3, 0, arr,l);
            //IsLychrel(394);
            //int count = 0;
            //for (int i = 1; i < 10000; i++)
            //{
            //    if (!IsLychrel(i))
            //    {
            //        count++;
            //    }
            //}
            //Console.WriteLine(count);
            //SameDigs();
            //GetTriPentHexNum();
            //pentsumdiff();
            //int[] arr = {0,3,2,2,7,9,8,13};
            //withoutoverlappingranges(arr);
            int[] arr={1,4,0,6,3,5,7,2,8,9};
            Console.WriteLine(CheckPanProp(arr));
            //ConcatenatedProductPandigital();
            //int[] arr = { 123, 456, 781 };
            Console.WriteLine(ConcatCheckPandigital(arr));
            //int[] arr={0,1,2,3,4,5,6,7,8,9};
            //List<long> nums = new List<long>();
            //perm(arr, 0, nums);
            //Console.WriteLine(nums.Sum());
            //sumofpandigitalmultiple();
            //smallestoddgoldbach();
            //numwordvalues();
            //getdig(1,0);
            //mulirrationalpositions();
            //highestpandigitalprime();
            //long[] fact = GetFactorials(10);
            //for(long i=10;i<10000000;i++)
            //{
            //    if(IsCurious(i,fact))
            //        Console.WriteLine(i);
            //}
            //areperms(0, 1301);
            //specialseq();
            //maxprimesequencesum(1000000);
            //int[] arrrem = { 0,1, 2, 3, 4,5,6,7,8,9 };
            //int[] output = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            //lexperm(arrrem, 1000000, output);
            //for (int j = 0; j < output.Length; j++)
            //{
            //    Console.Write(output[j]);
            //}
            //Console.WriteLine();
            //projecteuler48(10,1000);
            //pythagorean(1000);
            //Console.Write(testdiff("IIIIIIIIIIIIIIII"));
            //checkdiff();
            //Console.Write(ToRoman(16,romanvalues,newvalues));
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Console.WriteLine(ToRoman(452, romanvalues, newvalues).ToCharArray().Length);
            //CircularPrimes(1000000);
            //convergentfore(100);
            //NumberChain(10000000);
            ////narcissisticsum();
            //find(1, 1, 10);
            //testcontains();
            //Tuple<int,int> a=FactorizeGetNewAB(64,60);
            //NumberOfDistinctPowers(100, 100);
            //testnarcissisticcube();
            //diagonalsum(1001);
            //LargestRecurringCycle();
            //fib1000digits();
            //for (int i = 0; i < 120; i++)
            //{
            //int[] rem = { 0, 1, 2, 3, 4 };
            //int[] output = { -1, -1, -1, -1, -1 };
            ////Console.Write(i + " ");
            //FindNthLexicographicOrder(98, output, 0, rem);
            //}
            //FindLeastFactAndMul(23);
            //FindValueOfAllStrings();
            //int n = 28123;
            //Console.WriteLine(GetRequiredSum(n));
            //Console.WriteLine(IsSumOf2Abundant(100));
            //Console.WriteLine(GetRequiredSum(n));
            //Console.WriteLine(SumOfamicableNumbers(10000));
            //Console.WriteLine(DynamicProgSol(20));
            //FindTriangleNumberWithAtOverNDivisors(500);
            //LargestProduct();
            //prime();
            //findlistofprimes(Math.Pow(10,12));
            //long num = 600851475143;
            //findlistofprimes(num);
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed.TotalSeconds);
            Console.Read();
        }
    }
}