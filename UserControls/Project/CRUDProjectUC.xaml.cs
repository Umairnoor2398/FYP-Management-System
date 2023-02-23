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

namespace ProjectA.UserControls.Project
{
    /// <summary>
    /// Interaction logic for CRUDProjectUC.xaml
    /// </summary>
    public partial class CRUDProjectUC : UserControl
    {
        public CRUDProjectUC()
        {
            InitializeComponent();
            projectCC.Content = new AddProjectUC();
            ViewProjects();
        }
        private void ViewProjects()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Project P", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ProjectDataGrid.ItemsSource = dt.DefaultView;
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string title, description;
            DataRowView row = ProjectDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                title = row["Title"].ToString();
                description = row["Description"].ToString();
                projectCC.Content = new AddProjectUC(title, description, id);
                addProjectForm.Visibility = Visibility.Visible;
                viewProject.Visibility = Visibility.Collapsed;
                addStBtn.Content = "Back";
            }

        }
        private void deleteRecord(int id)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Project Where Id=@Id", con);
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
            DataRowView row = ProjectDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                deleteRecord(id);
                ViewProjects();
            }
        }
        private void addStBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addStBtn.Content.ToString() == "Add")
            {
                projectCC.Content = new AddProjectUC();
                addProjectForm.Visibility = Visibility.Visible;
                viewProject.Visibility = Visibility.Collapsed;
                addStBtn.Content = "Back";
            }
            else
            {
                ViewProjects();
                addProjectForm.Visibility = Visibility.Collapsed;
                viewProject.Visibility = Visibility.Visible;
                addStBtn.Content = "Add";
            }
        }
    }
}
