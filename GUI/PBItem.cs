using ProjectEuler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class PBItem
    {
        public string name { set; get; }
        public int id { set; get; }
    }

    public class PBItemArr: ObservableCollection<PBItem>
    {
        public PBItemArr()
        {
            this.init();
        }

        public void init()
        {
            this.Clear();
            Console.WriteLine("Loading problem list");
            foreach (int x in Toolbox.AvailableProblems)
            {
                Console.WriteLine("Found Problem {0:d3}", x);
                this.Add(new PBItem { name = string.Format("Problem {0:d3}", x), id = x });
            }
        }
    }
}
