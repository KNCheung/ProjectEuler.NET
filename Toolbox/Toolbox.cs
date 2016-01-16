using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace ProjectEuler
{
    public class Toolbox
    {
        private static FileInfo[] AlgorithmFiles
        {
            get
            {
                DirectoryInfo lib;
                try
                {
                    lib = new DirectoryInfo(@".\lib");
                }
                catch (DirectoryNotFoundException)
                {
                    return new FileInfo[0];
                }
                var problems = from x in lib.GetFiles()
                               where Regex.IsMatch(x.Name, @"^PB\d{3}\.dll")
                               orderby x.Name
                               select x;
                return problems.ToArray<FileInfo>();
            }
        }
        public static int[] AvailableProblems
        {
            get
            {
                return (from x in AlgorithmFiles
                        select int.Parse(Regex.Replace(x.Name, @"(PB0*)|(\.dll)", ""))).ToArray<int>();
            }
        }
        public static int LatestProblem
        {
            get
            {
                int min = 0;
                DateTime minTime = DateTime.MinValue;
                foreach (FileInfo f in AlgorithmFiles)
                    if (f.LastAccessTime > minTime)
                    {
                        min = int.Parse(Regex.Replace(f.Name, @"(PB0*)|(\.dll)", ""));
                        minTime = f.LastAccessTime;
                    }
                return min;
            }
        }
    }
}
