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

namespace ProjectA.UserControls.Advisor
{
    /// <summary>
    /// Interaction logic for AddAdvisorUC.xaml
    /// </summary>
    public partial class AddAdvisorUC : UserControl
    {
        public AddAdvisorUC()
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
        public void designationBtnClicked(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(profBtn))
            {
                profBtn.Background = Brushes.Purple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (sender.Equals(assocProfBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.Purple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (sender.Equals(assisProfBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.Purple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (sender.Equals(lecturerBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.Purple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (sender.Equals(industryBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.Purple;
            }
        }
    }
}
