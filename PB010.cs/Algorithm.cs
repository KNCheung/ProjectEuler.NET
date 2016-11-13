using System;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            long sum = 0;
            foreach (int p in MathLib.GetPrimes(2000000 - 1))
                sum += p;
            return sum.ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
