using System;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public long run(long n)
        {
            int[] primes = TroyMath.GetPrimes((int)Math.Ceiling(Math.Sqrt(n)));
            for (int i = primes.Length - 1; i >= 0; i--)
                if (n % primes[i] == 0)
                    return primes[i];
            return 0;
        }

        public string Compute()
        {
            return run(600851475143).ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
