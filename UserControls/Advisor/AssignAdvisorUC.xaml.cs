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
            SqlCommand cmd = new SqlCommand("Select Title from Project", con);
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

        private void assignMainAdvisorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void assignCoAdvisorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void assignIndustryAdvisorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void projectComboBox_DropDownClosed(object sender, EventArgs e)
        {
            GetProjectId(projectComboBox.Text);
        }
        private void mainAdvisorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string n1, n2;
            n1 = coAdvisorComboBox.Text;
            n2 = industryAdvisorComboBox.Text;
            AdvisorToComboBox(coAdvisorComboBox, mainAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            AdvisorToComboBox(industryAdvisorComboBox, coAdvisorComboBox.Text, mainAdvisorComboBox.Text);
            coAdvisorComboBox.Text = n1;
            industryAdvisorComboBox.Text = n2;
        }

        private void coAdvisorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string n1, n2;
            n1 = mainAdvisorComboBox.Text;
            n2 = industryAdvisorComboBox.Text;
            AdvisorToComboBox(mainAdvisorComboBox, coAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            AdvisorToComboBox(industryAdvisorComboBox, coAdvisorComboBox.Text, mainAdvisorComboBox.Text);
            mainAdvisorComboBox.Text = n1;
            industryAdvisorComboBox.Text = n2;

        }

        private void industryAdvisorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string n1, n2;
            n1 = mainAdvisorComboBox.Text;
            n2 = coAdvisorComboBox.Text;
            AdvisorToComboBox(mainAdvisorComboBox, coAdvisorComboBox.Text, industryAdvisorComboBox.Text);
            AdvisorToComboBox(coAdvisorComboBox, industryAdvisorComboBox.Text, mainAdvisorComboBox.Text);
            mainAdvisorComboBox.Text = n1;
            coAdvisorComboBox.Text = n2;

        }
    }
}
