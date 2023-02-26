using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.Data;
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
                SqlCommand cmd = new SqlCommand("SELECT CONCAT('G-',G.Id) AS GroupId,P.Title,GS.StudentId AS GStudent,G.Created_On FROM [Group] AS G LEFT JOIN GroupProject AS GP ON G.Id=GP.GroupId LEFT JOIN GroupStudent AS GS ON GS.GroupId=G.Id LEFT JOIN Project AS P ON GP.ProjectId=P.Id", con);
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
            try
            {
                int id = 0;
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Group](Created_On) VALUES(@date)", con);
                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                cmd.ExecuteNonQuery();
                //SqlDataReader reader = cmd.ExecuteReader();
                //if (reader.Read())
                //{; SELECT SCOPE_IDENTITY() AS Id;
                //    id = int.Parse(reader["Id"].ToString());
                //}
                MessageBox.Show("Group G-" + id + " Created Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DisplayGroups();
        }

        private void deleteRecord(int id)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Group] WHERE Id=@Id", con);
                //SqlCommand cmd1 = new SqlCommand("DELETE FROM Person Where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                //cmd1.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                MessageBox.Show("Record Deleted!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = GroupDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                string GroupId = row["GroupId"].ToString();
                string[] GId = GroupId.Split('-');
                int groupId = int.Parse(GId[1]);
                deleteRecord(groupId);
                DisplayGroups();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
