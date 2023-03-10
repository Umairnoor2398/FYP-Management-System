using CRUD_Operations;
using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ProjectA.UserControls.Group
{
    /// <summary>
    /// Interaction logic for CRUDGroupUC.xaml
    /// </summary>
    public partial class CRUDGroupUC : UserControl
    {
        public CRUDGroupUC()
        {
            InitializeComponent();
            DisplayGroups();
        }

        public void DisplayGroups()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT CONCAT('G-',G.Id) AS GroupId,P.Id AS ProjectId,P.Title,COUNT(GS.StudentId) AS GStudent,(SELECT FORMAT(G.Created_On, 'dd-MM-yyyy')) AS Created_On FROM [Group] AS G LEFT JOIN GroupProject AS GP ON G.Id=GP.GroupId LEFT JOIN GroupStudent AS GS ON GS.GroupId=G.Id LEFT JOIN Project AS P ON GP.ProjectId=P.Id WHERE GS.Status=3 GROUP BY G.Id,P.Id,P.Title,G.Created_On", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GroupDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            if (createGroupBtn.Content.ToString() == "Create New Group")
            {
                try
                {
                    int id = 0;
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Group](Created_On) VALUES(@date); SELECT Id FROM [Group] ORDER BY Id Desc", con);
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id = int.Parse(reader["Id"].ToString());
                    }
                    reader.Close();
                    MessageBox.Show("Group G-" + id + " Created Successfully");
                    groupUC.Content = new EditGroupUC(id);
                    createGroupBtn.Content = "Go Back";
                    editGroupForm.Visibility = Visibility.Visible;
                    GroupDataGrid.Visibility = Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                editGroupForm.Visibility = Visibility.Collapsed;
                GroupDataGrid.Visibility = Visibility.Visible;
                createGroupBtn.Content = "Create New Group";
            }
            DisplayGroups();
        }



        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = GroupDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                string GroupId = row["GroupId"].ToString();
                string projectId = row["ProjectId"].ToString();
                string[] GId = GroupId.Split('-');
                int groupId = int.Parse(GId[1]);
                groupUC.Content = new EditGroupUC(groupId, projectId);
                createGroupBtn.Content = "Go Back";
                editGroupForm.Visibility = Visibility.Visible;
                GroupDataGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void detailsBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = GroupDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                string GroupId = row["GroupId"].ToString();
                string projectId = row["ProjectId"].ToString();
                string[] GId = GroupId.Split('-');
                int groupId = int.Parse(GId[1]);
                groupUC.Content = new EditGroupUC(groupId, projectId, "Details");
                createGroupBtn.Content = "Go Back";
                editGroupForm.Visibility = Visibility.Visible;
                GroupDataGrid.Visibility = Visibility.Collapsed;
            }
        }
    }
}
