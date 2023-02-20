using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ProjectA.UserControls.Student
{
    /// <summary>
    /// Interaction logic for AddStudentUC.xaml
    /// </summary>
    public partial class AddStudentUC : UserControl
    {
        public AddStudentUC()
        {
            InitializeComponent();
        }

        public void genderBtnClicked(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(maleBtn))
            {
                maleBtn.Background = Brushes.Purple;
                femaleBtn.Background = Brushes.MediumPurple;
            }
            else
            {
                maleBtn.Background = Brushes.MediumPurple;
                femaleBtn.Background = Brushes.Purple;
            }
        }
    }
}
