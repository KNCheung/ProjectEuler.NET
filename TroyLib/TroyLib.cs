using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    /// <summary>
    /// 自定义数学库
    /// </summary>
    public static class TroyLib
    {
        private static List<long[]> Combination = new List<long[]>();

        /// <summary>
        /// 计算组合数(n,k)，即从n个元素选k个元素的方案数，有记忆能力
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static long C(int n, int k)
        {
            int t;
            if (k > n)
                throw new ArgumentException();
            if (n >= Combination.Count)
                while (n >= Combination.Count)
                {
                    t = Combination.Count;
                    Combination.Add(new long[t + 1]);
                    Combination[t][0] = 1;
                    Combination[t][t] = 1;
                }
            if (Combination[n][k] == 0)
                Combination[n][k] = C(n - 1, k - 1) + C(n - 1, k);
            return Combination[n][k];
        }

        /// <summary>
        /// 计算最大公约数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        /// <summary>
        /// 试除法素性测试
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool isPrime(long n)
        {
            if (n == 2)
                return true;
            if ((n <= 1) || ((n & 1) == 0))
                return false;
            for (long i = 3; i <= (long)Math.Ceiling(Math.Sqrt(n)); i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }

        /// <summary>
        /// 素数迭代器，需提供素性测试方法
        /// </summary>
        /// <param name="isPrime">素性测试方法</param>
        /// <param name="start">起始值</param>
        /// <returns></returns>
        public static IEnumerable<long> PrimeIterator(Func<long, bool> isPrime, long start=0)
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

        /// <summary>
        /// 回文串判定
        /// </summary>
        /// <param name="str">待测字符串</param>
        /// <returns></returns>
        public static bool isPalindrome(string str)
        {
            for (int i = 0; i < (str.Length >> 1); i++)
                if (str[i] != str[str.Length - i - 1])
                    return false;
            return true;
        }

        /// <summary>
        /// 欧拉筛法求素数表
        /// </summary>
        /// <param name="n">范围</param>
        /// <returns></returns>
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

        /// <summary>
        /// 速算 a^d % m
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static long PowMod(long a, long d, long m)
        {
            if (d == 0) return 1;
            if (d == 1) return a % m;
            if ((d & 1) == 0) return PowMod(a * a % m, d >> 1, m) % m;
            return PowMod(a * a % m, d >> 1, m) * a % m;
        }

        /// <summary>
        /// Miller-Rabin素性测试，有效范围0~1,122,004,669,633
        /// </summary>
        /// <param name="n">待测试数</param>
        /// <returns></returns>
        public static bool isPrimeMR(long n)
        {
            long d, t;
            int[] TestList = {2, 13, 23, 1662803};

            if (n == 2) return true;
            if ((n < 2) || ((n & 1) == 0)) return false;

            foreach (int a in TestList)
            {
                if (a >= n) break;
                d = n - 1;
                while ((d & 1) == 0) d >>= 1;
                t = PowMod(a, d, n);
                while ((d != n - 1) && (t != 1) && (t != n - 1))
                {
                    t = t * t % n;
                    d <<= 1;
                }
                if ((t != n - 1) && ((d & 1) != 1))
                    return false;
            }
            return true; 
        }
    }
}
