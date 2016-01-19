using System;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            int[] final = new int[primes.Length];
            int cnt;
            int i, j, t;

            for (i = 0; i < final.Length; i++)
                final[i] = 0;

            for (i = 1; i <= 20; i++)
            {
                t = i;
                for (j = 0; j < primes.Length; j++)
                {
                    cnt = 0;
                    while (t % primes[j] == 0)
                    {
                        cnt++;
                        t /= primes[j];
                    }
                    if (cnt > final[j])
                        final[j] = cnt;
                }
            }

            long ret = 1;
            for (i = 0; i < final.Length; i++)
                for (j = 0; j < final[i]; j++)
                    ret *= primes[i];
            return ret.ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
