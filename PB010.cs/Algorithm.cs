using System;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            long sum = 0;
            foreach (int p in TroyMath.GetPrimes(2000000 - 1))
                sum += p;
            return sum.ToString();
        }

        public bool prepare()
        {
            return true;
        }
    }
}
