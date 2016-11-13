using System;
using System.IO;
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
            FileInfo file = null;
            int n = 0;
            Console.WriteLine("The latest one is {0}\n", Toolbox.LatestAlgorithm.Name);

            try
            {
                Console.Write("Problem Number: ");
                n = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                file = Toolbox.LatestAlgorithm;
                Console.WriteLine("Input Error.\nSelect the latest One: {0}", file.Name);
            }

            Algorithm algo = null;
            if (file == null)
            {
                try
                {
                    Console.Write("Algorithm Language: ");
                    switch (Console.ReadLine().ToLower()[0])
                    {
                        case 'c':
                            algo = new Algorithm(n, AlgorithmLanguage.CSharp);
                            break;
                        case 'f':
                            algo = new Algorithm(n, AlgorithmLanguage.FSharp);
                            break;
                        default:
                            algo = new Algorithm(n, AlgorithmLanguage.Unknown);
                            break;
                    }
                }
                catch
                {
                    algo = new Algorithm(n);
                }
            }
            else
                algo = new Algorithm(file);
                
            if (algo.available)
            {
                Console.Title = string.Format("Problem {0:d3}", algo.n);
                algo.Prepare();
                if (algo.isPrepared)
                {
                    Console.WriteLine("\nStart ==>");
                    mainTask = Task.Run(() => { algo.Run(); });
                    if (algo.Progress != null)
                    {
                        while (!mainTask.IsCompleted)
                        {
                            Console.Write("{0:00.00%} {1}/{2}\r", algo.Progress.Percentage, algo.Progress.CurrentValue, algo.Progress.MaxValue);
                            Console.Title = string.Format("{0:00%} Problem {1:d3}", algo.Progress.Percentage, algo.n);
                            Thread.Sleep(100);
                        }
                        Console.WriteLine();
                    }
                    else
                        mainTask.Wait();
                }
                Console.Write("<== Finished\n\nAnswer: {0}\nTime: {1}\n", algo.answer, algo.time);
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
