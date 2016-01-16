using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class Troy
    {
        public static long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        public static bool isPrime(int n)
        {
            if (n == 2)
                return true;
            if ((n <= 1) || ((n & 1) == 0))
                return false;
            for (int i = 3; i <= (int)Math.Ceiling(Math.Sqrt(n)); i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }

        public static IEnumerable<int> PrimeIterator(Func<int, bool> isPrime, int start=0)
        {
            if (start <= 2)
            {
                yield return 2;
                start = 3;
            }
            if ((start & 1) == 0)
                start++;
            for (; ; start+=2)
                if (isPrime(start))
                    yield return start;
        }

        public static bool isPalindrome(string str)
        {
            for (int i = 0; i < (str.Length >> 1); i++)
                if (str[i] != str[str.Length - i - 1])
                    return false;
            return true;
        }

        public static int[] GetPrimes(int n)
        {
            bool[] flag = new bool[n+1];
            int i, j;
            List<int> ret = new List<int>();

            for (i = 0; i <= n; i++)
                flag[i] = true;
            flag[0] = false;
            flag[1] = false;
            i = 0;
            while (i <= n)
            {
                while ((i <= n) && (!flag[i])) i++;
                if (i > n)
                    break;
                ret.Add(i);
                j = i + i;
                while (j <= n)
                {
                    flag[j] = false;
                    j += i;
                }
                i++;
            }
            return ret.ToArray();
        }
    }
}
