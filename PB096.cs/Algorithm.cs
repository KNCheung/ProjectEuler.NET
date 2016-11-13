using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public class Sudoku
    {
        public enum SolveStatus
        {
            Solved,
            UnSolved,
            NoSolution
        };

        public readonly string Name;
        private SolveStatus _status = SolveStatus.UnSolved; 
        private readonly int[,] _candidate = new int[9, 9];
        private readonly int[,] _ans = new int[9, 9];

        public int this[int x, int y]
        {
            get { return this._ans[x, y]; }
            set
            {
                if (value == 0)
                    return;
                if (this.ContainCandidate(x, y, value))
                {
                    this._ans[x, y] = value;
                    this._candidate[x, y] = 0;
                    this.CleanCandidate(x, y, value);
                    this.FindUniqueAndFill();
                }
                else
                {
                    this._status = SolveStatus.NoSolution;
                }
            }
        }

        public SolveStatus Status
        {
            get
            {
                if (_status != SolveStatus.UnSolved) return _status;
                this.Check();
                return _status;
            }
        }

        public Sudoku(string problem = "", string name = "UNNAMED")
        {
            if (!Regex.IsMatch(problem, @"(\d\D*){81}"))
                throw new FormatException("Length not right");
            this.Name = name;
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                {
                    this._candidate[i, j] = 0x1ff;
                    this._ans[i, j] = 0;
                }
            var k = 0;
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                {
                    while (!(('0' <= problem[k]) && (problem[k] <= '9')))
                        k++;
                    this[i, j] = (int)(problem[k] - '0');
                    if (this._status == SolveStatus.NoSolution)
                        return;
                    k++;
                }
        }

        public Sudoku(Sudoku prev)
        {
            this.Name = prev.Name;
            this._status = prev._status;
            Array.Copy(prev._candidate, this._candidate, prev._candidate.Length);
            Array.Copy(prev._ans, this._ans, prev._ans.Length);
        }

        public List<int> GetCandidate(int x, int y)
        {
            var ret = new List<int>(); 
            for (var n = 0; n < 9; n++)
                if (((1 << n) & (this._candidate[x, y])) > 0)
                    ret.Add(n + 1);
            return ret;
        }

        public Tuple<int, int> NextUnsolved()
        {
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                    if (_candidate[i, j] > 0)
                        return new Tuple<int, int>(i, j);
            return new Tuple<int, int>(-1, -1);
        }

        private void Check()
        {
            this._status = SolveStatus.Solved;
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                {
                    if ((_ans[i, j] == 0) && (_candidate[i, j] == 0))
                    {
                        this._status = SolveStatus.NoSolution;
                        return;
                    }
                    if (_candidate[i, j] > 0)
                        this._status = SolveStatus.UnSolved;
                }
        }

        private void FindUniqueAndFill()
        {
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                    if (_ans[i, j] == 0)
                    {
                        var tmp = GetCandidate(i, j);
                        if (tmp.Count == 1)
                        {
                            this[i, j] = tmp[0];
                            return;
                        }
                    } 
        }

        private bool ContainCandidate(int x, int y, int value)
        {
            return (this._ans[x, y] == value) || 
                    ((this._candidate[x, y] & (1 << (value - 1))) > 0);
        }

        private void RemoveCandidate(int x, int y, int target)
        {
            this._candidate[x, y] &= (0x1FF ^ (1 << (target - 1)));
            var candidate = GetCandidate(x, y);
            if ((candidate.Count == 0) && (this._ans[x, y] == 0))
                this._status = SolveStatus.NoSolution;
        }

        private void CleanCandidate(int x, int y, int value)
        {
            // === Row & Column ===
            for (var i = 0; i < 9; i++)
            {
                this.RemoveCandidate(x, i, value);
                this.RemoveCandidate(i, y, value);
            }
            // === House ===
            var offsetX = (x/3)*3;
            var offsetY = (y/3)*3;
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    this.RemoveCandidate(offsetX + i, offsetY + j, value); 
        }

        public override string ToString()
        {
            var ret = "";
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                    ret += _ans[i, j].ToString();
                ret += "\n";
            }
            return ret;
        }
    }

    public class Algorithm : IAlgorithm
    {

        private Sudoku IterSolver(Sudoku curr)
        {
            var coord = curr.NextUnsolved();
            foreach (var item in curr.GetCandidate(coord.Item1, coord.Item2))
            {
                var tmp = new Sudoku(curr);
                tmp[coord.Item1, coord.Item2] = item;
                switch (tmp.Status)
                {
                    case Sudoku.SolveStatus.Solved:
                        return tmp;
                    case Sudoku.SolveStatus.UnSolved:
                        tmp = IterSolver(tmp);
                        if (tmp.Status == Sudoku.SolveStatus.Solved)
                            return tmp;
                        break;
                    case Sudoku.SolveStatus.NoSolution:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return curr;
        }

        private readonly List<Tuple<string, string>> _problem = new List<Tuple<string, string>>();
        public string Compute()
        {
            var sum = 0;
            foreach (var item in _problem)
            {
                var tmp = new Sudoku(item.Item2, item.Item1);
                if (tmp.Status == Sudoku.SolveStatus.UnSolved)
                    tmp = IterSolver(tmp);
                System.Console.WriteLine("{0}{1}\n{2}", tmp.Name,tmp.Status,tmp);
                sum += tmp[0, 0]*100 + tmp[0, 1]*10 + tmp[0, 2];
            }
            return sum.ToString();
        }

        public bool Prepare()
        {
            foreach (
                Match item in
                Regex.Matches(Properties.Resources.data096, @"(?'name'Grid\s\d\d[\r\n]*?)(?'sudoku'(\d{9}[\r\n]*?){9})"))
            {
                _problem.Add(new Tuple<string, string>(item.Groups["name"].ToString(), item.Groups["sudoku"].ToString()));
            }
            return true;
        }
    }
}
