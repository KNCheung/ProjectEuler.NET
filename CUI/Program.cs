using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

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
