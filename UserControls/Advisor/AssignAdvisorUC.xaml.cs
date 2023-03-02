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
using System.Text.RegularExpressions;

namespace ProjectA.UserControls.Advisor
{
    /// <summary>
    /// Interaction logic for AssignAdvisorUC.xaml
    /// </summary>
    public partial class AssignAdvisorUC : UserControl
    {
        private int projectId;
        public AssignAdvisorUC()
        {
            InitializeComponent();
            ProjectToComboBox();
            AdvisorToComboBox(mainAdvisorComboBox, "", "");
            AdvisorToComboBox(coAdvisorComboBox, "", "");
            AdvisorToComboBox(industryAdvisorComboBox, "", "");
        }

        public AssignAdvisorUC(int projectId, string adv1, string adv2, string adv3)
        {
            InitializeComponent();
            AllProjectToComboBox();
            projectComboBox.Text = GetProjectTitle(projectId);
            projectComboBox.IsEnabled = false;
            AdvisorToComboBox(mainAdvisorComboBox, adv2, adv3);
            AdvisorToComboBox(coAdvisorComboBox, adv1, adv3);
            AdvisorToComboBox(industryAdvisorComboBox, adv1, adv2);
            mainAdvisorComboBox.Text = adv1;
            coAdvisorComboBox.Text = adv2;
            industryAdvisorComboBox.Text = adv3;
        }

        private void AllProjectToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Title from Project", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            projectComboBox.ItemsSource = dt.Tables[0].DefaultView;
            projectComboBox.DisplayMemberPath = "Title";
        }

        private void AdvisorToComboBox(ComboBox cb, string adv1, string adv2)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT (P.FirstName+' '+P.LastName) AS Name FROM Advisor A JOIN Person P ON A.Id=P.Id WHERE (P.FirstName+' '+P.LastName)<>@name1 AND (P.FirstName+' '+P.LastName)<>@name2", con);
                cmd.Parameters.AddWithValue("@name1", adv1);
                cmd.Parameters.AddWithValue("@name2", adv2);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                cb.ItemsSource = dataSet.Tables[0].DefaultView;
                cb.DisplayMemberPath = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ProjectToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Title from Project P LEFT JOIN ProjectAdvisor PA ON P.Id=PA.ProjectId WHERE PA.AdvisorId IS NULL", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            projectComboBox.ItemsSource = dt.Tables[0].DefaultView;
            projectComboBox.DisplayMemberPath = "Title";
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

        private string GetProjectTitle(int Id)
        {
            string title = "";
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT Title FROM Project WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    title = reader["Title"].ToString();
                }
                reader.Close();
                return title;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }

        private int AdvisorIdFromDataBase(string Name)
        {
            int id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT P.Id FROM Person P JOIN Advisor A ON A.Id=P.Id WHERE (P.FirstName+' '+P.LastName)=@Name", con);
            cmd.Parameters.AddWithValue("@Name", Name);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return id;
        }

        private int GetAdvisorRole(string role)
        {
            int id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Lookup WHERE Value='" + role + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return id;
        }

        private void AssignAdvisor(string query, int role, int advId)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                cmd.Parameters.AddWithValue("@AdvisorId", advId);
                cmd.Parameters.AddWithValue("@AdvisorRole", role);
                cmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Advisor Assigned Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int IsAdvisorPresent(int role)
        {
            int id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT AdvisorId FROM ProjectAdvisor WHERE ProjectId=@ProjectId AND AdvisorRole=@role", con);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            cmd.Parameters.AddWithValue("@role", role);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id = int.Parse(reader["AdvisorId"].ToString());
            }
            reader.Close();
            return id;
        }


        private void assignMainAdvisorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (projectComboBox.Text == string.Empty)
            {
                MessageBox.Show("Select a Project First");
            }
            else if (mainAdvisorComboBox.Text == string.Empty)
            {
                MessageBox.Show("Select an Advisor to be assigned");
            }
            else
            {

                string query;
                int id = GetAdvisorRole("Main Advisor");
                int advId = AdvisorIdFromDataBase(mainAdvisorComboBox.Text);
                if (IsAdvisorPresent(id) == 0)
                {
                    query = "INSERT INTO ProjectAdvisor VALUES (@AdvisorId, @ProjectId, @AdvisorRole, @AssignmentDate)";
                }
                else
                {
                    query = "UPDATE ProjectAdvisor SET AssignmentDate=@AssignmentDate, AdvisorId=@AdvisorId WHERE ProjectId=@ProjectId AND AdvisorRole =@AdvisorRole";
                }
                AssignAdvisor(query, id, advId);
            }

        }

        private void assignCoAdvisorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (projectComboBox.Text == string.Empty)
            {
                MessageBox.Show("Select a Project First");
            }
            else if (coAdvisorComboBox.Text == string.Empty)
            {
                MessageBox.Show("Select an Advisor to be assigned");
            }
            else
            {

                string query;
                int id = GetAdvisorRole("Co-Advisor");
                int advId = AdvisorIdFromDataBase(coAdvisorComboBox.Text);
                if (IsAdvisorPresent(id) == 0)
                {
                    query = "INSERT INTO ProjectAdvisor VALUES (@AdvisorId, @ProjectId, @AdvisorRole, @AssignmentDate)";
                }
                else
                {
                    query = "UPDATE ProjectAdvisor SET AssignmentDate=@AssignmentDate, AdvisorId=@AdvisorId WHERE ProjectId=@ProjectId AND AdvisorRole =@AdvisorRole";
                }
                AssignAdvisor(query, id, advId);
            }
        }

        private void assignIndustryAdvisorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (projectComboBox.Text == string.Empty)
            {
                MessageBox.Show("Select a Project First");
            }
            else if (industryAdvisorComboBox.Text == string.Empty)
            {
                MessageBox.Show("Select an Advisor to be assigned");
            }
            else
            {

                string query;
                int id = GetAdvisorRole("Industry Advisor");
                int advId = AdvisorIdFromDataBase(industryAdvisorComboBox.Text);
                if (IsAdvisorPresent(id) == 0)
                {
                    query = "INSERT INTO ProjectAdvisor VALUES (@AdvisorId, @ProjectId, @AdvisorRole, @AssignmentDate)";
                }
                else
                {
                    query = "UPDATE ProjectAdvisor SET AssignmentDate=@AssignmentDate, AdvisorId=@AdvisorId WHERE ProjectId=@ProjectId AND AdvisorRole =@AdvisorRole";
                }
                AssignAdvisor(query, id, advId);
            }
        }

        private void projectComboBox_DropDownClosed(object sender, EventArgs e)
        {
            GetProjectId(projectComboBox.Text);
        }
        private void mainAdvisorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string advisor1, advisor2;
            advisor1 = coAdvisorComboBox.Text;
            advisor2 = industryAdvisorComboBox.Text;
            AdvisorToComboBox(coAdvisorComboBox, mainAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            coAdvisorComboBox.Text = advisor1;
            industryAdvisorComboBox.Text = advisor2;
            AdvisorToComboBox(industryAdvisorComboBox, coAdvisorComboBox.Text, mainAdvisorComboBox.Text);
            coAdvisorComboBox.Text = advisor1;
            industryAdvisorComboBox.Text = advisor2;
        }

        private void coAdvisorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string advisor1, advisor2;
            advisor1 = mainAdvisorComboBox.Text;
            advisor2 = industryAdvisorComboBox.Text;
            AdvisorToComboBox(mainAdvisorComboBox, coAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            mainAdvisorComboBox.Text = advisor1;
            industryAdvisorComboBox.Text = advisor2;
            AdvisorToComboBox(industryAdvisorComboBox, coAdvisorComboBox.Text, mainAdvisorComboBox.Text);
            mainAdvisorComboBox.Text = advisor1;
            industryAdvisorComboBox.Text = advisor2;
        }

        private void industryAdvisorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string advisor1, advisor2;
            advisor1 = mainAdvisorComboBox.Text;
            advisor2 = coAdvisorComboBox.Text;
            AdvisorToComboBox(mainAdvisorComboBox, coAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            mainAdvisorComboBox.Text = advisor1;
            coAdvisorComboBox.Text = advisor2;
            AdvisorToComboBox(coAdvisorComboBox, mainAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            mainAdvisorComboBox.Text = advisor1;
            coAdvisorComboBox.Text = advisor2;

        }
    }
}
