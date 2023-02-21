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
            addBtn.Content = "Add";
        }

        public AddStudentUC(string FName, string LName, string contact, string email, int gender, string regno, string dob, int id)
        {
            InitializeComponent();
            addBtn.Content = "Update";
            txtFirstName.Text = FName;
            txtLastName.Text = LName;
            txtContact.Text = contact;
            txtEmail.Text = email;
            txtRegNo.Text = regno;
            dobDatePicker.SelectedDate = DateTime.Parse(dob);
            this.id = id;
            if (gender == 1)
            {
                maleBtn.Background = Brushes.Purple;
                femaleBtn.Background = Brushes.MediumPurple;
            }
            else
            {
                maleBtn.Background = Brushes.MediumPurple;
                femaleBtn.Background = Brushes.Purple;
            }
        }

        public void genderBtnClicked(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(maleBtn))
            {
                maleBtn.Background = Brushes.Purple;
                femaleBtn.Background = Brushes.MediumPurple;
                gender = 1;
            }
            else
            {
                maleBtn.Background = Brushes.MediumPurple;
                femaleBtn.Background = Brushes.Purple;
                gender = 2;
            }
        }

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Clear();
            txtRegNo.Clear();
            txtEmail.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            maleBtn.Background = Brushes.Purple;
            femaleBtn.Background = Brushes.MediumPurple;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addBtn.Content.ToString() == "Add")
            {

                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Person(FirstName,LastName,Contact,Email,DateOfBirth,Gender) VALUES (@FirstName,@LastName, @Contact,@Email,@DateOfBirth, @Gender)", con);
                    SqlCommand cmd1 = new SqlCommand("insert into Student(Id,RegistrationNo) VALUES ((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName=@LastName AND Contact=@Contact AND Email=@Email AND DateOfBirth=@DateOfBirth AND Gender=@Gender) ,@RegNo)", con);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd1.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd1.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd1.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd1.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd1.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                    cmd1.Parameters.AddWithValue("@Gender", gender);
                    cmd1.Parameters.AddWithValue("@RegNo", txtRegNo.Text);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
