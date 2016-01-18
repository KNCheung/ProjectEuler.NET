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
            List<Task> taskList = new List<Task>();
            int cnt = 0;
            Action testF = () => {
                foreach (int x in Troy.PrimeIterator(Troy.isPrime))
                    if (++cnt > 1000000)
                        break;
            };
            Action<Task> testDone = (t) =>
            {
                Console.WriteLine("Thread #{0} Done", t.Id);
            };
            taskList.Add(Task.Run(testF));
            taskList[0].ContinueWith(testDone);
            Thread.Sleep(10000);
            taskList.Add(Task.Run(testF));
            while (!taskList[0].IsCompleted || !taskList[1].IsCompleted)
            {
                Console.Write("{0}\r", cnt);
                Thread.Sleep(1000);
            }
            taskList[1].Wait();
            Console.WriteLine("\nFinished");
            Console.ReadKey(true);
        }
    }
}
