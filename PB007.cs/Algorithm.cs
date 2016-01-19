using System;
using System.Collections;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            int cnt = 10001;
            foreach (int prime in TroyMath.PrimeIterator(TroyMath.isPrime))
                if ((--cnt) == 0)
                    return prime.ToString();
            return "";
        }

        public bool prepare()
        {
            return true;
        }
    }
}
