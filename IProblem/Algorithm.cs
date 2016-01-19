using System;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public class AlgorithmFileInfo
    {
        private FileInfo file = null;

        public string FileName
        {
            get
            {
                return file.FullName;
            }
        }

        public string Name
        {
            get
            {
                return file.Name;
            }
        }

        public int n { private set; get; }

        public AlgorithmLanguage lang { private set; get; }

        public AlgorithmFileInfo(FileInfo file = null)
        {
            if (file == null)
                throw new ArgumentException("Missing Argument: file");
            this.file = file;
            this.n = int.Parse(Regex.Match(file.Name, @"[1-9]\d*").Value);
            switch ((file.Name.Split('.')[1].ToLower()))
            {
                case "cs":
                    this.lang = AlgorithmLanguage.CSharp;
                    break;
                case "fs":
                    this.lang = AlgorithmLanguage.FSharp;
                    break;
                default:
                    this.lang = AlgorithmLanguage.Unknown;
                    break;
            }
        }

        public AlgorithmFileInfo(int n, AlgorithmLanguage lang)
        {
            string suffix;
            this.n = n;
            this.lang = lang;
            switch (lang)
            {
                case AlgorithmLanguage.CSharp:
                    suffix = ".cs";
                    break;
                case AlgorithmLanguage.FSharp:
                    suffix = ".fs";
                    break;
                default:
                    suffix = "";
                    break;
            }
            this.file = new FileInfo(string.Format(@"lib\PB{0:d3}{1}.dll", n, suffix));
        }
    }

    public class Algorithm
    {
        private object algo = null;
        private Stopwatch stopwatch = new Stopwatch();
        private AlgorithmFileInfo file = null;

        public bool isPrepared { private set; get; }
        public TimeSpan time { private set; get; }
        public bool available { private set; get; }
        public int n { 
            get
            {
                return file.n;
            } }
        public string answer { private set; get; }
        public CProgress Progress = null;
        public AlgorithmLanguage lang = AlgorithmLanguage.Unknown;

        public Algorithm(int n = 0, AlgorithmLanguage lang = AlgorithmLanguage.CSharp)
        {
            this.time = TimeSpan.MaxValue;
            this.available = false;
            this.answer = "";
            this.isPrepared = false;

            this.file = new AlgorithmFileInfo(n, lang);

            loadProblem();
        }

        public Algorithm(AlgorithmFileInfo file)
        {
            this.file = file;
            this.time = TimeSpan.MaxValue;
            this.available = false;
            this.answer = "";
            this.isPrepared = false;
            loadProblem();
        }

        public Algorithm(FileInfo file)
        {
            if (!Regex.IsMatch(file.Name, @"^PB\d{3}(\.\w+)?\.dll$"))
                throw new ArgumentException("Not an available file");

            this.file = new AlgorithmFileInfo(file);
            this.time = TimeSpan.MaxValue;
            this.available = false;
            this.answer = "";
            this.isPrepared = false;
            loadProblem(); 
        }

        private void loadProblem()
        {
            try
            {
                Console.Write("Try to load {0}... ", file.FileName);
                Assembly asm = Assembly.LoadFrom(file.FileName);
                Console.Write("OK\nTry to create the Algorithm Object... ");
                this.algo = asm.CreateInstance("ProjectEuler.Algorithm");
                Console.WriteLine("OK");
                this.available = true;
                if (algo is IProgress)
                {
                    Console.WriteLine("Found IProgress interface implement");
                    Progress = new CProgress();
                    Progress = ((IProgress)algo).Progress;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed with exception\nMESSAGE: {0}", e.Message);
                this.available = false;
                this.algo = null;
            }
        }

        public bool Prepare()
        {
            if (this.available)
                this.isPrepared = ((IAlgorithm)algo).Prepare();
            return this.isPrepared;
        }

        public void Run()
        {
            if (!this.isPrepared)
                Prepare();
            if (this.available && this.isPrepared)
            {
                stopwatch.Reset();
                stopwatch.Start();
                this.answer = ((IAlgorithm)this.algo).Compute();
                stopwatch.Stop();
                this.time = stopwatch.Elapsed;
            }
        }
    }
}
