using System;
using System.IO;
using System.Resources;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        List<BigInteger> data = new List<BigInteger>();

        public string compute()
        {
            BigInteger sum = 0;
            foreach (BigInteger x in data)
                sum += x;
            return sum.ToString().Remove(10);
        }

        public bool prepare()
        {
            foreach (string n in Properties.Resources.data.Split('\n'))
                data.Add(BigInteger.Parse(n));
            return true;
        }
    }
}
