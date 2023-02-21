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

namespace ProjectA.UserControls
{
    /// <summary>
    /// Interaction logic for CRUDStudent.xaml
    /// </summary>
    public partial class CRUDStudent : UserControl
    {
        public CRUDStudent()
        {
            InitializeComponent();
            studentCC.Content = new UserControls.Student.AddStudentUC();
            ViewStudent();
        }

        private void ViewStudent()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Person P JOIN Student S ON S.Id=P.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            StudentDataGrid.ItemsSource = dt.DefaultView;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(StudentDataGrid.SelectedIndex.ToString());
            string FName, LName, contact, email, regno, dob;
            int gender;
            DataRowView row = StudentDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                FName = row["FirstName"].ToString();
                LName = row["LastName"].ToString();
                contact = row["Contact"].ToString();
                email = row["Email"].ToString();
                regno = row["RegistrationNo"].ToString();
                dob = row["DateOfBirth"].ToString();
                gender = int.Parse(row["Gender"].ToString());
                studentCC.Content = new Student.AddStudentUC(FName, LName, contact, email, gender, regno, dob, id);
                addStudentForm.Visibility = Visibility.Visible;
                viewStudent.Visibility = Visibility.Collapsed;
                addStBtn.Content = "Back";
            }

        }
        private void deleteRecord(int id)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Student Where Id=@Id; DELETE FROM Person Where Id=@Id;", con);
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
            DataRowView row = StudentDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                deleteRecord(id);
                ViewStudent();
            }
        }

        private void addStBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addStBtn.Content.ToString() == "Add")
            {
                addStudentForm.Visibility = Visibility.Visible;
                viewStudent.Visibility = Visibility.Collapsed;
                addStBtn.Content = "Back";
            }
            else
            {
                ViewStudent();
                addStudentForm.Visibility = Visibility.Collapsed;
                viewStudent.Visibility = Visibility.Visible;
                addStBtn.Content = "Add";
            }
        }
    }
}
