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

namespace ProjectA.UserControls.Advisor
{
    /// <summary>
    /// Interaction logic for AddAdvisorUC.xaml
    /// </summary>
    public partial class AddAdvisorUC : UserControl
    {
        int id;
        public AddAdvisorUC()
        {
            InitializeComponent();
            GenderToComboBox();
            DesignationToComboBox();
        }
        public AddAdvisorUC(string FName, string LName, string contact, string email, string gender, string designation, string salary, string dob, int id)
        {
            InitializeComponent();
            GenderToComboBox();
            DesignationToComboBox();
            addBtn.Content = "Update";
            txtFirstName.Text = FName;
            txtLastName.Text = LName;
            txtContact.Text = contact;
            txtEmail.Text = email;
            txtSalary.Text = salary;
            dobDatePicker.SelectedDate = DateTime.Parse(dob);
            this.id = id;
            genderCB.Text = gender;
            designationCB.Text = designation;
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

        private void DesignationToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Value from Lookup WHERE Category=\'DESIGNATION\'", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            designationCB.ItemsSource = dt.Tables[0].DefaultView;
            designationCB.DisplayMemberPath = "Value";
        }

        public int giveGender(string gen)
        {
            int g = -1;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Lookup WHERE Category=\'GENDER\' AND Value=@gender", con);
            cmd.Parameters.AddWithValue("@gender", gen);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                g = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return g;
        }
        public int giveDesignation(string desig)
        {
            int d = -1;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Lookup WHERE Category=\'DESIGNATION\' AND Value=@DESIGNATION", con);
            cmd.Parameters.AddWithValue("@DESIGNATION", desig);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                d = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return d;
        }

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtSalary.Clear();
            dobDatePicker.Text = string.Empty;
            genderCB.Text = string.Empty;
            designationCB.Text = string.Empty;
        }
        private void CloseUserControl()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while ((parent != null) && !(parent is CRUDAdvisor))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is CRUDAdvisor)
            {
                CRUDAdvisor crudStudent = (CRUDAdvisor)parent;
                crudStudent.ViewAdvisors();
                Button btn = (Button)crudStudent.FindName("addBtn");
                DataGrid AdvisorDataGrid = (DataGrid)crudStudent.FindName("AdvisorDataGrid");
                btn.Content = "Add";
                AdvisorDataGrid.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
        }

        private bool Validation()
        {
            bool isValid = true;
            if (!Validations.FirstNameValidations(txtFirstName.Text))
            {
                return false;
            }
            if (!Validations.LastNameValidations(txtLastName.Text))
            {
                return false;
            }
            if (!Validations.ContactValidations(txtContact.Text))
            {
                return false;
            }
            if (!Validations.EmailValidations(txtEmail.Text))
            {
                return false;
            }
            if (!Validations.SalaryValidations(txtSalary.Text))
            {
                return false;
            }
            if (!Validations.DoBValidations(dobDatePicker.Text, 1970, 1995))
            {
                return false;
            }

            return isValid;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int gender = giveGender(genderCB.Text);
            int desig = giveDesignation(designationCB.Text);

            if (Validation())
            {
                if (designationCB.Text != "")
                {
                    int salary = 0;
                    if (txtSalary.Text != "")
                    {
                        salary = int.Parse(txtSalary.Text);
                    }
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
                            cmd.Parameters.AddWithValue("@Salary", salary);
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
                            SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName, LastName=@LastName, Contact=@Contact, Email=@Email, DateOfBirth=@DateOfBirth, Gender=@Gender WHERE Id=@Id; UPDATE Advisor SET Designation=@Designation, Salary=@Salary WHERE Id=@Id;", con);
                            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@DateOfBirth", dobDatePicker.SelectedDate.ToString());
                            cmd.Parameters.AddWithValue("@Gender", gender);
                            cmd.Parameters.AddWithValue("@Designation", desig);
                            cmd.Parameters.AddWithValue("@Salary", salary);
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
                    CloseUserControl();
                }
                else
                {
                    MessageBox.Show("Please Select Designation of the Advisor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
