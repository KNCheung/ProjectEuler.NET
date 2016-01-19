using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            BigInteger n = 1;
            for (int i = 0; i < 1000; i++)
                n *= 2;
            return Enumerable.Sum<Char>(n.ToString().ToCharArray(), (x) => ((int)(x - '0'))).ToString();
        }

        public bool prepare()
        {
            return true;
        }
    }
}
