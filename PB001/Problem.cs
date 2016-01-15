using System;

namespace ProjectEuler
{
    public class Problem : IProblem
    {
        private int run(int n)
        {
            int sum = 0;
            for (int i = 1; i < n; i++)
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum += i;
            return sum;
        }

        public string compute()
        {
            return string.Format("{0}", run(1000));
        }

        public bool prepare()
        {
            return true;
        }
    }
}
