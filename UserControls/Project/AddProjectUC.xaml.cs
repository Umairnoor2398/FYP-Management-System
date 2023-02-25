using CRUD_Operations;
using ProjectA.UserControls.Evaluation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml.Linq;

namespace ProjectA.UserControls.Project
{
    /// <summary>
    /// Interaction logic for AddProjectUC.xaml
    /// </summary>
    public partial class AddProjectUC : UserControl
    {
        int id;
        public AddProjectUC()
        {
            InitializeComponent();
            addBtn.Content = "Add";
        }
        public AddProjectUC(string title, string description, int id)
        {
            InitializeComponent();
            addBtn.Content = "Update";
            txtTitle.Text = title;
            txtDescription.Text = description;
            this.id = id;
        }

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Clear();
            txtDescription.Clear();
        }
        private void findParentControls()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while ((parent != null) && !(parent is CRUDProjectUC))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is CRUDProjectUC)
            {
                CRUDProjectUC crudProject = (CRUDProjectUC)parent;
                crudProject.ViewProjects();
                Button btn = (Button)crudProject.FindName("addBtn");
                DataGrid ProjectDataGrid = (DataGrid)crudProject.FindName("ProjectDataGrid");
                btn.Content = "Add";
                ProjectDataGrid.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Please Add Title of Project", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Describe the project a little bit to save it", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (addBtn.Content.ToString() == "Add")
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Project(Title,Description) VALUES (@Title,@Description)", con);
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully saved");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("UPDATE Project SET Title = @Title, Description=@Description WHERE Id=@Id;", con);
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                findParentControls();
            }
        }
    }
}
