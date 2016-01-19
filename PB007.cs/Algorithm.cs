using System;
using System.Collections;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            int cnt = 10001;
            foreach (int prime in TroyMath.PrimeIterator(TroyMath.isPrime))
                if ((--cnt) == 0)
                    return prime.ToString();
            return "";
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
