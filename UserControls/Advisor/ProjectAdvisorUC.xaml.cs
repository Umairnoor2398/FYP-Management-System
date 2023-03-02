using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for ProjectAdvisorUC.xaml
    /// </summary>
    public partial class ProjectAdvisorUC : UserControl
    {
        public ProjectAdvisorUC()
        {
            InitializeComponent();
            ViewAdvisoryBoard();
        }
        public void ViewAdvisoryBoard()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT PA.ProjectId, MAX(P.Title) Title, MAX(CASE WHEN PA.AdvisorRole = 11 THEN CONCAT(Person.FirstName,' ',Person.LastName) END) AS MainAdvisor, MAX(CASE WHEN PA.AdvisorRole = 12 THEN CONCAT(Person.FirstName,' ',Person.LastName) END) AS CoAdvisor, MAX(CASE WHEN PA.AdvisorRole = 14 THEN CONCAT(Person.FirstName,' ',Person.LastName) END) AS IndustryAdvisor FROM  ProjectAdvisor PA INNER JOIN Advisor A ON PA.AdvisorId = A.Id JOIN Project P ON P.Id=PA.ProjectId JOIN Person ON Person.Id=A.Id GROUP BY PA.ProjectId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AdvisorBoardDataGrid.ItemsSource = dt.DefaultView;
        }


        private void deleteRecord(int id)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM ProjectAdvisor Where ProjectId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = AdvisorBoardDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["ProjectId"].ToString());
                deleteRecord(id);
                ViewAdvisoryBoard();
            }
        }


        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = AdvisorBoardDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["ProjectId"].ToString());
                string adv1 = row["MainAdvisor"].ToString();
                string adv2 = row["CoAdvisor"].ToString();
                string adv3 = row["IndustryAdvisor"].ToString();
                advisorBoardAddUC.Content = new AssignAdvisorUC(id, adv1, adv2, adv3);
                advisorBoardScroll.Visibility = Visibility.Visible;
                AdvisorBoardDataGrid.Visibility = Visibility.Collapsed;
                assignBtn.Content = "Back";
            }
        }

        private void assignBtn_Click(object sender, RoutedEventArgs e)
        {
            if (assignBtn.Content.ToString() == "Assign Advisor")
            {
                advisorBoardAddUC.Content = new AssignAdvisorUC();
                advisorBoardScroll.Visibility = Visibility.Visible;
                AdvisorBoardDataGrid.Visibility = Visibility.Collapsed;
                assignBtn.Content = "Back";
            }
            else
            {
                ViewAdvisoryBoard();
                advisorBoardScroll.Visibility = Visibility.Collapsed;
                AdvisorBoardDataGrid.Visibility = Visibility.Visible;
                assignBtn.Content = "Assign Advisor";
            }
        }
    }
}
