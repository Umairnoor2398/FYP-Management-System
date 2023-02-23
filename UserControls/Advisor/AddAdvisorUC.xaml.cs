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

namespace ProjectA.UserControls.Advisor
{
    /// <summary>
    /// Interaction logic for AddAdvisorUC.xaml
    /// </summary>
    public partial class AddAdvisorUC : UserControl
    {
        int gender = 1;
        int desig = 3;
        int id;
        public AddAdvisorUC()
        {
            InitializeComponent();
            dobDatePicker.SelectedDate = DateTime.Now;
        }
        public AddAdvisorUC(string FName, string LName, string contact, string email, int gender, int designation, string salary, string dob, int id)
        {
            InitializeComponent();
            addBtn.Content = "Update";
            txtFirstName.Text = FName;
            txtLastName.Text = LName;
            txtContact.Text = contact;
            txtEmail.Text = email;
            txtSalary.Text = salary;
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
            this.gender = gender;
            this.desig = designation;
            if (designation == 3)
            {
                profBtn.Background = Brushes.Purple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (designation == 4)
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.Purple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (designation == 5)
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.Purple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;

            }
            else if (designation == 6)
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.Purple;
                industryBtn.Background = Brushes.MediumPurple;
            }
            else if (designation == 7)
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.Purple;
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
        public void designationBtnClicked(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(profBtn))
            {
                profBtn.Background = Brushes.Purple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
                desig = 3;
            }
            else if (sender.Equals(assocProfBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.Purple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
                desig = 4;
            }
            else if (sender.Equals(assisProfBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.Purple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.MediumPurple;
                desig = 5;
            }
            else if (sender.Equals(lecturerBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.Purple;
                industryBtn.Background = Brushes.MediumPurple;
                desig = 6;
            }
            else if (sender.Equals(industryBtn))
            {
                profBtn.Background = Brushes.MediumPurple;
                assocProfBtn.Background = Brushes.MediumPurple;
                assisProfBtn.Background = Brushes.MediumPurple;
                lecturerBtn.Background = Brushes.MediumPurple;
                industryBtn.Background = Brushes.Purple;
                desig = 7;
            }
        }

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtSalary.Clear();
            dobDatePicker.SelectedDate = DateTime.Now;
            this.gender = 1;
            this.desig = 3;
            this.id = -1;

            maleBtn.Background = Brushes.Purple;
            femaleBtn.Background = Brushes.MediumPurple;

            profBtn.Background = Brushes.Purple;
            assocProfBtn.Background = Brushes.MediumPurple;
            assisProfBtn.Background = Brushes.MediumPurple;
            lecturerBtn.Background = Brushes.MediumPurple;
            industryBtn.Background = Brushes.MediumPurple;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addBtn.Content.ToString() == "Save")
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Person(FirstName,LastName,Contact,Email,DateOfBirth,Gender) VALUES (@FirstName,@LastName, @Contact,@Email,@DateOfBirth, @Gender); INSERT INTO Advisor(Id,Designation,Salary) VALUES ((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName=@LastName AND Contact=@Contact AND Email=@Email AND DateOfBirth=@DateOfBirth AND Gender=@Gender) ,@Designation, @Salary);", con);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Designation", desig);
                    cmd.Parameters.AddWithValue("@Salary", int.Parse(txtSalary.Text));
                    cmd.ExecuteNonQuery();
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
                    SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName, LastName=@LastName, Contact=@Contact, Email=@Email, DateOfBirth=@DateOfBirth, Gender=@Gender WHERE Id=@Id; UPDATE Advisor SET Designation=@Designation, Salary=@Salary WHERE Id=@Id;", con);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Designation", desig);
                    cmd.Parameters.AddWithValue("@Salary", int.Parse(txtSalary.Text));
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
