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
    /// Interaction logic for EditGroupUC.xaml
    /// </summary>
    public partial class EditGroupUC : UserControl
    {
        private int groupId;
        private int projectId;
        public EditGroupUC(int groupId)
        {
            InitializeComponent();
            this.groupId = groupId;
            groupNameDisplayTextBlock.Text = "G-" + groupId;
            ProjectToComboBox();
            GetStudentsOfGroup(studentsInGroupDataGrid);
            StudentToComboBox();
        }
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
            ProjectToComboBox();
            GetStudentsOfGroup(studentsInGroupDataGrid);
            StudentToComboBox();
        }

        private void GetAllStudentsOfGroup()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT CONCAT(P.FirstName ,' ',P.LastName) AS Name,S.Id ,S.RegistrationNo ,L.Value AS Status  FROM GroupStudent AS GS JOIN Lookup AS L ON GS.Status = L.Id JOIN Student AS S ON S.Id = GS.StudentId JOIN Person AS P ON P.Id = S.Id WHERE GS.GroupId = @GroupId", con);
            cmd.Parameters.AddWithValue("@GroupId", groupId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            groupDetailsStudentDataGrid.ItemsSource = dt.DefaultView;
        }

        public EditGroupUC(int groupId, string projectId, string type)
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
            GetAllStudentsOfGroup();
            projectComboBoxBorder.Visibility = Visibility.Collapsed;
            studentComboBoxBorder.Visibility = Visibility.Collapsed;
            studentsInGroupDataGrid.Visibility = Visibility.Collapsed;
            groupDetailsStudentDataGrid.Visibility = Visibility.Visible;
        }

        private void GetStudentsOfGroup(DataGrid dg)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT CONCAT(P.FirstName ,' ',P.LastName) AS Name,S.Id ,S.RegistrationNo ,L.Value AS Status  FROM GroupStudent AS GS JOIN Lookup AS L ON GS.Status = L.Id JOIN Student AS S ON S.Id = GS.StudentId JOIN Person AS P ON P.Id = S.Id WHERE GS.GroupId = @GroupId AND GS.Status=@Status", con);
            cmd.Parameters.AddWithValue("@GroupId", groupId);
            cmd.Parameters.AddWithValue("@Status", 3);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
        }

        private void ProjectToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Title from Project WHERE Id<>'" + projectId + "'", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            projectComboBox.ItemsSource = dt.Tables[0].DefaultView;
            projectComboBox.DisplayMemberPath = "Title";
        }
        private void StudentToComboBox()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                //SqlCommand cmd = new SqlCommand("SELECT RegistrationNo FROM Student AS S LEFT JOIN GroupStudent AS GS ON S.Id = GS.StudentId WHERE GS.StudentId IS NULL OR GS.Status = 4", con);
                SqlCommand cmd = new SqlCommand("SELECT s.RegistrationNo FROM Student s LEFT JOIN (SELECT * FROM GroupStudent GS1 WHERE GS1.AssignmentDate = ( SELECT MAX(GS2.AssignmentDate) FROM GroupStudent GS2 WHERE GS2.StudentId = GS1.StudentId)) recent ON s.Id = recent.StudentID WHERE recent.Status = 4 OR recent.GroupID IS NULL", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                studentComboBox.ItemsSource = dataSet.Tables[0].DefaultView;
                studentComboBox.DisplayMemberPath = "RegistrationNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void GetCurrentProjectAssigned()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT Title FROM Project AS P,GroupProject AS GP WHERE  P.Id=GP.ProjectId AND GP.GroupId=@GroupId", con);
                cmd.Parameters.AddWithValue("@GroupId", groupId);
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

        private void GetProjectId(string title)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT Id FROM Project WHERE Title=@title", con);
                cmd.Parameters.AddWithValue("@title", title);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    projectId = int.Parse(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void assignProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (projectComboBox.Text == string.Empty)
            {
                MessageBox.Show("You need To First Select a project to assign to this group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            GetProjectId(projectComboBox.Text);
            if (projectTitleTextBlock.Text == "Not Assigned")
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO GroupProject VALUES (@ProjectId, @GroupId, @Date)", con);
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    //assignProjectBtn.Content = "Re-Assign";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("UPDATE GroupProject SET ProjectId=@ProjectId,AssignmentDate=@Date WHERE GroupId=@GroupId", con);
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            GetCurrentProjectAssigned();
            ProjectToComboBox();
            projectComboBox.Text = string.Empty;
            MessageBox.Show("Project Assigned Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private int StudentIdFromDataBase()
        {
            int id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Student AS S WHERE S.RegistrationNo=@RegNo", con);
            cmd.Parameters.AddWithValue("@RegNo", studentComboBox.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return id;
        }


        private void addStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            int stuId;
            if (studentComboBox.Text != string.Empty)
            {
                stuId = StudentIdFromDataBase();
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO GroupStudent VALUES (@GroupId, @StudentId,@Status,@Date)", con);
                    cmd.Parameters.AddWithValue("@StudentId", stuId);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", 3);
                    cmd.ExecuteNonQuery();
                    studentComboBox.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            StudentToComboBox();
            GetStudentsOfGroup(studentsInGroupDataGrid);
        }

        private void StatusButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = studentsInGroupDataGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("UPDATE GroupStudent SET Status=@Status WHERE GroupId=@GroupId AND StudentId = @StudentId", con);
                    cmd.Parameters.AddWithValue("@StudentId", int.Parse(selectedRow["Id"].ToString()));
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@Status", 4);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            GetStudentsOfGroup(studentsInGroupDataGrid);

        }
    }
}
