using System;
using System.Collections;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        private static IEnumerable fibonacci()
        {
            int a, b, c;
            a = 1;
            yield return a;
            b = 1;
            yield return b;
            for (;;)
            {
                c = a + b;
                yield return c;
                a = b;
                b = c;
            }
        }

        public string compute()
        {
            long sum = 0;
            foreach (int x in fibonacci())
                if (x <= 4000000)
                {
                    if ((x & 1) == 0)
                        sum += x;
                }
                else
                    break;
            return sum.ToString();
        }

        public bool prepare()
        {
            return true;
        }
    }
}
