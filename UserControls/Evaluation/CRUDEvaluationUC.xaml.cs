using CRUD_Operations;
using ProjectA.UserControls.Project;
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

namespace ProjectA.UserControls.Evaluation
{
    /// <summary>
    /// Interaction logic for CRUDEvaluationUC.xaml
    /// </summary>
    public partial class CRUDEvaluationUC : UserControl
    {
        public CRUDEvaluationUC()
        {
            InitializeComponent();
            evaluationCC.Content = new AddEvaluationUC();
            ViewEvaluation();
        }
        public void ViewEvaluation()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Name,TotalMarks,TotalWeightage from Evaluation E", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EvaluationDataGrid.ItemsSource = dt.DefaultView;
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string Name, TotalMarks, TotalWeightage;
            DataRowView row = EvaluationDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                Name = row["Name"].ToString();
                TotalMarks = row["TotalMarks"].ToString();
                TotalWeightage = row["TotalWeightage"].ToString();
                evaluationCC.Content = new AddEvaluationUC(Name, TotalMarks, TotalWeightage, id);
                addEvaluationForm.Visibility = Visibility.Visible;
                EvaluationDataGrid.Visibility = Visibility.Collapsed;
                addBtn.Content = "Back";
            }

        }
        private void deleteRecord(int id)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Evaluation Where Id=@Id", con);
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
            DataRowView row = EvaluationDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = Int32.Parse(row["Id"].ToString());
                deleteRecord(id);
                ViewEvaluation();
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addBtn.Content.ToString() == "Add")
            {
                evaluationCC.Content = new AddEvaluationUC();
                addEvaluationForm.Visibility = Visibility.Visible;
                EvaluationDataGrid.Visibility = Visibility.Collapsed;
                addBtn.Content = "Back";
            }
            else
            {
                ViewEvaluation();
                addEvaluationForm.Visibility = Visibility.Collapsed;
                EvaluationDataGrid.Visibility = Visibility.Visible;
                addBtn.Content = "Add";
            }
        }
    }
}
