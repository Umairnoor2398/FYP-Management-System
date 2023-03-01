using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectA.UserControls;
using ProjectA.UserControls.Student;
using ProjectA.UserControls.Advisor;
using ProjectA.UserControls.Project;
using ProjectA.UserControls.Evaluation;
using ProjectA.UserControls.Group;

namespace ProjectA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMaximized = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }
        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            CC.Content = null;
            if (sender.Equals(dashboardBtn))
            {
                CC.Content = null;
            }
            else if (sender.Equals(studentBtn))
            {
                CC.Content = new CRUDStudent();
            }
            else if (sender.Equals(advisorBtn))
            {
                CC.Content = new CRUDAdvisor();
            }
            else if (sender.Equals(projectBtn))
            {
                CC.Content = new CRUDProjectUC();
            }
            else if (sender.Equals(evaluationBtn))
            {
                CC.Content = new CRUDEvaluationUC();
            }
            else if (sender.Equals(markEvaluationBtn))
            {
                CC.Content = new MarkEvaluationDisplayUC();
            }
            else if (sender.Equals(groupBtn))
            {
                CC.Content = new CRUDGroupUC();
            }
            else if (sender.Equals(assignAdvisorBtn))
            {
                CC.Content = new ProjectAdvisorUC();
            }
            else if (sender.Equals(reportBtn))
            {
                CC.Content = null;
            }
            else if (sender.Equals(assignProjectBtn))
            {
                CC.Content = null;
            }
            else if (sender.Equals(exitBtn))
            {
                Thread.Sleep(500);
                Application.Current.Shutdown();
            }
        }
    }
}
