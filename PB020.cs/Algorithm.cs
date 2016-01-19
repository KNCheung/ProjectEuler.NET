using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            BigInteger factorial = BigInteger.One;
            for (int i = 1; i <= 100; i++)
                factorial *= i;
            return Enumerable.Sum<Char>(factorial.ToString().ToCharArray(), (x) => ((int)(x - '0'))).ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
