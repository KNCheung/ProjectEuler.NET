using System;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            return TroyMath.C(40, 20).ToString();
        }

        public bool prepare()
        {
            return true;
        }
    }
}
