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
                               where Regex.IsMatch(x.Name, @"^PB\d{3}(.\w+)?\.dll")
                               orderby x.Name
                               select x;
                return problems.ToArray<FileInfo>();
            }
        }
        public static FileInfo[] AvailableAlgorithms
        {
            get
            {
                return AlgorithmFiles;
            }
        }
        public static FileInfo LatestAlgorithm
        {
            get
            {
                FileInfo[] lst = AlgorithmFiles;
                FileInfo min = lst[0];
                foreach (FileInfo f in lst)
                    if (f.LastAccessTime > min.LastAccessTime)
                        min = f;
                return min;
            }
        }
    }
}
