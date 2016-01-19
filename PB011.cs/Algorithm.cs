using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        int[,] data = null;
        int n = 0;

        private int grid(int x, int y)
        {
            if ((0 <= x) && (x < n) && (0 <= y) && (y < n))
                return data[x, y];
            else
                return 0;
        }

        public string Compute()
        {
            int max = int.MinValue;
            int t;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    t = grid(i, j) * grid(i - 1, j + 1) * grid(i - 2, j + 2) * grid(i - 3, j + 3);
                    if (t > max)
                        max = t;

                    t = grid(i, j) * grid(i, j + 1) * grid(i, j + 2) * grid(i, j + 3);
                    if (t > max)
                        max = t;

                    t = grid(i, j) * grid(i + 1, j + 1) * grid(i + 2, j + 2) * grid(i + 3, j + 3);
                    if (t > max)
                        max = t;

                    t = grid(i, j) * grid(i + 1, j) * grid(i + 2, j) * grid(i + 3, j);
                    if (t > max)
                        max = t;
                }
            return max.ToString();
        }

        public bool Prepare()
        {
            var rawDatas = (from str in Properties.Resources.data.Split('\n')
                            where Regex.IsMatch(str, @"^\s*(\d+\s+)+$")
                            select str).ToArray<string>();
            n = rawDatas.Length;
            data = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var t = (from num in rawDatas[i].Split(' ')
                         where Regex.IsMatch(num, @"\d+")
                         select int.Parse(num)).ToArray<int>();
                for (int j = 0; j < n; j++)
                    data[i, j] = t[j];
            }
            return true;
        }
    }
}
