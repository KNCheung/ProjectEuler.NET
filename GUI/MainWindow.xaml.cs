using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
            newProblemSelected();
            this.TaskbarItemInfo = new TaskbarItemInfo();
            this.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Error;
            this.TaskbarItemInfo.ProgressValue = 1;
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
    }
}
