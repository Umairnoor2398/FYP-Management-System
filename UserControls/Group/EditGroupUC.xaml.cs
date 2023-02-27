using CRUD_Operations;
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

namespace ProjectA.UserControls.Group
{
    /// <summary>
    /// Interaction logic for EditGroupUC.xaml
    /// </summary>
    public partial class EditGroupUC : UserControl
    {
        private int groupId;
        private int projectId;
        public EditGroupUC(int groupId, string projectId)
        {
            InitializeComponent();
            this.groupId = groupId;
            try
            {
                this.projectId = int.Parse(projectId);
                GetCurrentProjectAssigned();
            }
            catch
            {
                projectTitleTextBlock.Text = "Not Assigned";
            }
            groupNameDisplayTextBlock.Text = "G-" + groupId;
        }

        private void GetCurrentProjectAssigned()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT Title FROM Project WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", projectId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    projectTitleTextBlock.Text = reader["Title"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

    }
}
