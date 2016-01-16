using System.Collections.Generic;

namespace ProjectEuler
{
    public static class Troy
    {
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
