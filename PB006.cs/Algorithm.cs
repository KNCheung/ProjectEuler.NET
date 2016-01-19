using System;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            long SumOfSquare=0, SquareOfSum=0;
            for (int i = 0; i <= 100; i++)
            {
                SumOfSquare += i * i;
                SquareOfSum += i;
            }
            SquareOfSum *= SquareOfSum;
            return (SquareOfSum - SumOfSquare).ToString();
        }

        public bool prepare()
        {
            return true;
        }
    }
}
