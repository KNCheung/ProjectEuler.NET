using System;
using System.Reflection;
using System.Diagnostics;

namespace ProjectEuler
{
    public class Problem
    {
        private object algo = null;
        private Stopwatch stopwatch = new Stopwatch();

        public bool isPrepared { private set; get; }
        public TimeSpan time { private set; get; }
        public bool available { private set; get; }
        public int num { private set; get; }
        public string answer { private set; get; }
        public CProgress Progress = null;

        public Problem(int n = 0)
        {
            this.num = n;
            this.time = TimeSpan.MaxValue;
            this.available = false;
            this.answer = "";
            this.isPrepared = false;

            loadProblem(n);
        }

        private void loadProblem(int n)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(string.Format(@"lib\PB{0:d3}.dll", n));
                this.algo = asm.CreateInstance("ProjectEuler.Algorithm");
                this.available = true;
                if (algo is IProgress)
                {
                    Progress = new CProgress();
                    Progress = ((IProgress)algo).Progress;
                }
            }
            catch
            {
                this.available = false;
                this.algo = null;
            }
        }

        public bool prepare()
        {
            if (this.available)
                this.isPrepared = ((IProblem)algo).prepare();
            return this.isPrepared;
        }

        public void run()
        {
            if (!this.isPrepared)
                prepare();
            if (this.available && this.isPrepared)
            {
                stopwatch.Reset();
                stopwatch.Start();
                this.answer = ((IProblem)this.algo).compute();
                stopwatch.Stop();
                this.time = stopwatch.Elapsed;
            }
        }
    }
}
