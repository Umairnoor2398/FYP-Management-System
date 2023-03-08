using CRUD_Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

namespace ProjectA.UserControls.Student
{
    /// <summary>
    /// Interaction logic for AddStudentUC.xaml
    /// </summary>
    public partial class AddStudentUC : UserControl
    {
        int gender = 1;
        int id;
        public AddStudentUC()
        {
            InitializeComponent();
            GenderToComboBox();
            addBtn.Content = "Add";
            //dobDatePicker.SelectedDate = DateTime.Now;
        }

        private void GenderToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Value from Lookup WHERE Category=\'GENDER\'", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            genderCB.ItemsSource = dt.Tables[0].DefaultView;
            genderCB.DisplayMemberPath = "Value";
        }

        public AddStudentUC(string FName, string LName, string contact, string email, string gen, string regno, string dob, int id)
        {
            InitializeComponent();
            GenderToComboBox();
            addBtn.Content = "Update";
            txtFirstName.Text = FName;
            txtLastName.Text = LName;
            txtContact.Text = contact;
            txtEmail.Text = email;
            txtRegNo.Text = regno;
            dobDatePicker.SelectedDate = DateTime.Parse(dob);
            this.id = id;
            genderCB.Text = gen;
        }
        public int giveGender(string gen)
        {
            int g = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Lookup WHERE Category='GENDER' AND Value=@gender", con);
            cmd.Parameters.AddWithValue("@gender", gen);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                g = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return g;
        }

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Clear();
            txtRegNo.Clear();
            txtEmail.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            genderCB.Text = string.Empty;
            dobDatePicker.Text = string.Empty;
        }

        private void findParentControls()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while ((parent != null) && !(parent is CRUDStudent))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is CRUDStudent)
            {
                CRUDStudent crudStudent = (CRUDStudent)parent;
                crudStudent.ViewStudent();
                Button btn = (Button)crudStudent.FindName("addStBtn");
                DataGrid StudentDataGrid = (DataGrid)crudStudent.FindName("StudentDataGrid");
                btn.Content = "Add";
                StudentDataGrid.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            gender = giveGender(genderCB.Text);
            if (txtRegNo.Text == "")
            {
                MessageBox.Show("Please Select Registration of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please Select First Name of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Please Select Last Name of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (genderCB.Text == "")
            {
                MessageBox.Show("Please Select Gender of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dobDatePicker.Text == "")
            {
                MessageBox.Show("Please Select Date Of Birth of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Please Select Contact of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Select EMail of the Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (addBtn.Content.ToString() == "Add")
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Person(FirstName,LastName,Contact,Email,DateOfBirth,Gender) VALUES (@FirstName,@LastName, @Contact,@Email,@DateOfBirth, @Gender); insert into Student(Id,RegistrationNo) VALUES ((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName=@LastName AND Contact=@Contact AND Email=@Email AND DateOfBirth=@DateOfBirth AND Gender=@Gender) ,@RegNo);", con);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@RegNo", txtRegNo.Text);
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
                        SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName, LastName=@LastName, Contact=@Contact, Email=@Email, DateOfBirth=@DateOfBirth, Gender=@Gender WHERE Id=@Id; UPDATE Student SET RegistrationNo=@RegNo WHERE Id=@Id;", con);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@RegNo", txtRegNo.Text);
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
