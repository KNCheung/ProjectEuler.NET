using System;

using ProjectEuler;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int n = 0; n < 100; n++)
            {
                for (int k = 0; k <= n; k++)
                    Console.Write("{0} ", TroyMath.C(n, k));
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
