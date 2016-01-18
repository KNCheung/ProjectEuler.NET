using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectEuler;
using System.Windows.Shell;
using System.ComponentModel;

namespace GUI
{
    internal class DataSource: INotifyPropertyChanged
    {
        public double Progress_MaxValue { set; get; }
        public double Progress_MinValue { set; get; }
        public double Progress_CurrentValue { set; get; }

        private CProgress ProgressSource = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataSource()
        {
            Progress_MaxValue = 100;
            Progress_MinValue = 0;
            Progress_CurrentValue = 0;
        }

        public void SetProgressSource(CProgress source)
        {
            ProgressSource = source;
            Update();
        }

        public void Update()
        {
            if (ProgressSource != null)
            {
                Progress_CurrentValue = ProgressSource.CurrentValue;
                Progress_MaxValue = ProgressSource.MaxValue;
                Progress_MinValue = ProgressSource.MinValue;

                OnPropertyChanged(null);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void TimerUpdate(Object stateInfo)
        {
            Update();
        }
    }
}
