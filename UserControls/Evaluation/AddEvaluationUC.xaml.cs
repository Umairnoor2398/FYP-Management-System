using CRUD_Operations;
using System;
using System.Collections.Generic;
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

namespace ProjectA.UserControls.Evaluation
{
    /// <summary>
    /// Interaction logic for AddEvaluationUC.xaml
    /// </summary>
    public partial class AddEvaluationUC : UserControl
    {
        int id;
        public AddEvaluationUC()
        {
            InitializeComponent();
            addBtn.Content = "Add";
        }
        public AddEvaluationUC(string name, string totalMarks, string totalWeightage, int id)
        {
            InitializeComponent();
            addBtn.Content = "Update";
            txtName.Text = name;
            txtTotalMarks.Text = totalMarks;
            txtTotalWeightage.Text = totalWeightage;
            this.id = id;
        }

        private bool WeightageSumCalculate(int weightage)
        {
            int totalWeightage = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT SUM(TotalWeightage) AS total FROM Evaluation WHERE Id<>'" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalWeightage = int.Parse(reader["total"].ToString());
            }
            reader.Close();
            if (totalWeightage + weightage > 100)
            {
                return false;
            }
            return true;
        }

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtTotalMarks.Clear();
            txtTotalWeightage.Clear();
        }
        private void findParentControls()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while ((parent != null) && !(parent is CRUDEvaluationUC))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is CRUDEvaluationUC)
            {
                CRUDEvaluationUC crudEvaluation = (CRUDEvaluationUC)parent;
                crudEvaluation.ViewEvaluation();
                Button btn = (Button)crudEvaluation.FindName("addBtn");
                DataGrid EvaluationDataGrid = (DataGrid)crudEvaluation.FindName("EvaluationDataGrid");
                btn.Content = "Add";
                EvaluationDataGrid.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
        }

        private bool Validation()
        {
            string title = txtName.Text;
            bool titleValid = false;
            if (title == "")
            {
                return false;
            }
            string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
            foreach (char n in title)
            {
                if (Alphabets.Contains(n.ToString()))
                {
                    titleValid = true;
                }
            }
            if (titleValid)
            {
                titleValid = !Validations.ValidationInDatabase("SELECT Name FROM Evaluation WHERE Name='" + title + "' AND Id<>" + id);
                if (!titleValid)
                {
                    MessageBox.Show("There already exists one Evaluation With the same name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Evaluation Title must contain at least one Alphabet", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return titleValid;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Select Name of the Evaluation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtTotalMarks.Text == "")
            {
                MessageBox.Show("Please Select Total Marks of the Evaluation " + txtName.Text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtTotalWeightage.Text == "")
            {
                MessageBox.Show("Please Select Total Weightahe of the Evaluation " + txtName.Text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!WeightageSumCalculate(int.Parse(txtTotalWeightage.Text.ToString())))
            {
                MessageBox.Show("Total Weightage of Over All Evaluations cannot be over 100", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Validation())
            {
                if (addBtn.Content.ToString() == "Add")
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Evaluation(Name,TotalMarks,TotalWeightage) VALUES (@Name,@TotalMarks,@TotalWeightage)", con);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
                        cmd.Parameters.AddWithValue("@TotalWeightage", txtTotalWeightage.Text);
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
                        SqlCommand cmd = new SqlCommand("UPDATE Evaluation SET Name = @Name, TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage WHERE Id=@Id;", con);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
                        cmd.Parameters.AddWithValue("@TotalWeightage", txtTotalWeightage.Text);
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
