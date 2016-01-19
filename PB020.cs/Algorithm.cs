using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            BigInteger factorial = BigInteger.One;
            for (int i = 1; i <= 100; i++)
                factorial *= i;
            return Enumerable.Sum<Char>(factorial.ToString().ToCharArray(), (x) => ((int)(x - '0'))).ToString();
        }

        public bool prepare()
        {
            return true;
        }
    }
}
