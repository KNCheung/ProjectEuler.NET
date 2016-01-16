using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            foreach (int i in Toolbox.AvailableProblems)
                Console.WriteLine("Found Problem {0:d3}", i);
            Console.WriteLine("The latest one is Problem {0:d3}\n", Toolbox.LatestProblem);

            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                n = Toolbox.LatestProblem;
                Console.WriteLine("Input Error.\nRun the latest One: Problem {0:d3}", n);
            }

            Problem prob = new Problem(n);
            if (prob.available)
            {
                prob.prepare();
                if (prob.isPrepared)
                    prob.run();
                Console.Write("Finished\nAnswer: {0}\nTime: {1}\n", prob.answer, prob.time);
            }
            else
            {
                Console.WriteLine("Error Accured");
            }

            Console.WriteLine("The End\nPress any key to continue...");
            Console.ReadKey(true);
        } 
    }
}
