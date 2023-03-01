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
    /// Interaction logic for CRUDAdvisor.xaml
    /// </summary>
    public partial class CRUDAdvisor : UserControl
    {
        public CRUDAdvisor()
        {
            InitializeComponent();
            advisorCC.Content = new UserControls.Advisor.AddAdvisorUC();
            ViewAdvisors();
        }
        public void ViewAdvisors()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select P.Id,L1.Value AS Designation,A.Salary, (FirstName + ' ' + LastName) AS Name,L.Value AS Gender,(SELECT FORMAT(DateOfBirth, 'dd-MM-yyyy')) AS [DoB],Contact,Email from Person P JOIN Advisor A ON A.Id=P.Id JOIN Lookup L ON L.Id=P.Gender JOIN Lookup L1 ON L1.Id=A.Designation", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AdvisorDataGrid.ItemsSource = dt.DefaultView;
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string name, FName, LName, contact, email, salary, dob;
            string gender, designation;
            DataRowView row = AdvisorDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                name = row["Name"].ToString();
                string[] names = name.Split(' ');
                FName = names[0];
                LName = names[1];
                contact = row["Contact"].ToString();
                email = row["Email"].ToString();
                designation = row["Designation"].ToString();
                salary = row["Salary"].ToString();
                dob = row["DoB"].ToString();
                gender = row["Gender"].ToString();
                advisorCC.Content = new Advisor.AddAdvisorUC(FName, LName, contact, email, gender, designation, salary, dob, id);
                addAdvisorForm.Visibility = Visibility.Visible;
                AdvisorDataGrid.Visibility = Visibility.Collapsed;
                addBtn.Content = "Back";
            }

        }
        private void deleteRecord(int id)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Advisor Where Id=@Id; DELETE FROM Person Where Id=@Id;", con);
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
            DataRowView row = AdvisorDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                deleteRecord(id);
                ViewAdvisors();
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addBtn.Content.ToString() == "Add")
            {
                advisorCC.Content = new AddAdvisorUC();
                addAdvisorForm.Visibility = Visibility.Visible;
                AdvisorDataGrid.Visibility = Visibility.Collapsed;
                addBtn.Content = "Back";
            }
            else
            {
                ViewAdvisors();
                addAdvisorForm.Visibility = Visibility.Collapsed;
                AdvisorDataGrid.Visibility = Visibility.Visible;
                addBtn.Content = "Add";
            }
        }
    }
}
