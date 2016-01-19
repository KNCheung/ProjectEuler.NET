using System;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            int a = 0, b = 0, c = 0;
            for (a = 1; a < 1000; a++)
                for (b = a; (b < 1000) && (a + b < 1000); b++)
                {
                    c = 1000 - a - b;
                    if (a * a + b * b == c * c)
                        return (a * b * c).ToString();
                }
            return "";
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
