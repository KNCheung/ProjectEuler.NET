using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        private static Task mainTask = null;
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
                {
                    mainTask = Task.Run(() => { prob.run(); });
                    if (prob.Progress != null)
                    {
                        while (!mainTask.IsCompleted)
                        {
                            Console.Write("{0:00.00%} {1}/{2}\r", prob.Progress.Percentage, prob.Progress.CurrentValue, prob.Progress.MaxValue);
                            Thread.Sleep(100);
                        }
                        Console.WriteLine();
                    }
                    else
                        mainTask.Wait();
                }
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
