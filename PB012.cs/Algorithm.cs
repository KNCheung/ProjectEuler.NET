using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        private IEnumerable<long> TriangularNumber()
        {
            long i = 0, sum = 0;
            while (true)
            {
                i++;
                sum += i;
                yield return sum;
            }
        }

        private int FactorsCount(long n)
        {
            int cnt = 0, x;
            for (x = 1; x * x < n; x++)
                if (n % x == 0)
                    cnt += 2;
            if (x * x == n)
                cnt++;
            return cnt;
        }

        public string Compute()
        {
            foreach (long x in TriangularNumber())
                if (FactorsCount(x) > 500)
                    return x.ToString();
            return "";
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
