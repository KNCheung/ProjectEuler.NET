using System;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            return MathLib.C(40, 20).ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
