using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        Dictionary<long, long> link = new Dictionary<long, long>();

        private long Next(long n)
        {
            if ((n & 1) == 0)
                return n >> 1;
            else
                return 3 * n + 1;
        }

        private long iter(long n)
        {
            if (!link.ContainsKey(n))
                link.Add(n, iter(Next(n)) + 1);
            return link[n];
        }

        public string Compute()
        {
            long maxLength = long.MinValue;
            long maxN = 0;
            long length = 0;
            link.Add(1, 1);
            for (long i = 1; i < 1000000; i++)
            {
                length = iter(i);
                if (length > maxLength)
                {
                    maxLength = length;
                    maxN = i;
                }
            }
            return maxN.ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
