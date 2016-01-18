using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ProjectEuler;

namespace GUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskbarItemInfo taskbar = new TaskbarItemInfo();
        private DataSource data = new DataSource();
        private Timer updateTimer = null;

        public MainWindow()
        {
            InitializeComponent();
            DataBinding(data);
            newProblemSelected();
        }

        private void DataBinding(DataSource data)
        {
            this.TaskbarItemInfo = taskbar;

            PBar.SetBinding(ProgressBar.MaximumProperty, new Binding() { Source = data, Path = new PropertyPath("Progress_MaxValue"), Mode = BindingMode.OneWay });
            PBar.SetBinding(ProgressBar.MinimumProperty, new Binding() { Source = data, Path = new PropertyPath("Progress_MinValue"), Mode = BindingMode.OneWay });
            PBar.SetBinding(ProgressBar.ValueProperty, new Binding() { Source = data, Path = new PropertyPath("Progress_CurrentValue"), Mode = BindingMode.OneWay });

        }

        private void problemList_Initialized(object sender, EventArgs e)
        {
            problemList.ItemsSource = new PBItemArr();
            problemList.SelectedValuePath = "id";
            problemList.DisplayMemberPath = "name";
            problemList.SelectedValue = Toolbox.LatestProblem;
        }

        private void problemSelected(object sender, SelectionChangedEventArgs e)
        {
            newProblemSelected();
        }

        private void newProblemSelected()
        {
            if (problemList.SelectedValue != null)
                btnRun.Content = string.Format("Run Problem {0:d3}", (int)problemList.SelectedValue);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ((PBItemArr)problemList.ItemsSource).init();
            problemList.SelectedValue = Toolbox.LatestProblem;
        }

        Task mainTask = null;
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if ((mainTask == null) || (mainTask.IsCompleted))
            {
                Problem prob = new Problem((int)problemList.SelectedValue);
                data.SetProgressSource(prob.Progress);

                prob.prepare();
                mainTask = Task.Run(() => { prob.run(); });
                updateTimer = new Timer(data.TimerUpdate, null, 0, 50);
                btnRun.Content = "Running";
            }
            data.Update();
            Console.WriteLine("{0} {1}", PBar.Value, PBar.Maximum);
        }
    }
}
