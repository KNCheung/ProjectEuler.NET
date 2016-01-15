using System;
using System.Reflection;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int n = int.Parse(Console.ReadLine());
            IProblem prob = loadProblem(n);

            if (prob != null)
                if (prob.prepare())
                {
                    stopwatch.Start();
                    Console.WriteLine(prob.compute());
                    stopwatch.Stop();
                    Console.WriteLine("Time usage: {0} ms", stopwatch.ElapsedMilliseconds);
                }
                else
                    Console.WriteLine("Preparation failed");
            else
                Console.WriteLine("Error accured");

            Console.WriteLine("The End\nPress any key to continue...");
            Console.ReadKey(true);
        }

        private static IProblem loadProblem(int n)
        {
            IProblem prob = null;
            try
            {
                Assembly asm = Assembly.LoadFrom(string.Format(@"lib\PB{0:d3}.dll", n));
                prob = (IProblem)asm.CreateInstance("ProjectEuler.Problem");
            }
            catch
            {
            }
            return prob;
        }
    }
}
