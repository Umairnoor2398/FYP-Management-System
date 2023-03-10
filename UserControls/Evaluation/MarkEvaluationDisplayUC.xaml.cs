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

namespace ProjectA.UserControls.Evaluation
{
    /// <summary>
    /// Interaction logic for MarkEvaluationDisplayUC.xaml
    /// </summary>
    public partial class MarkEvaluationDisplayUC : UserControl
    {
        public MarkEvaluationDisplayUC()
        {
            InitializeComponent();
            DisplayMarkedEValuations();
        }
        public void DisplayMarkedEValuations()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select CONCAT('G-',GroupId) AS GroupId,Name,EvaluationId,TotalMarks,ObtainedMarks,(SELECT FORMAT(EvaluationDate, 'dd-MM-yyyy')) AS [EvaluationDate] FROM GroupEvaluation EV JOIN Evaluation E ON EV.EvaluationId=E.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MarkedEvaluationDataGrid.ItemsSource = dt.DefaultView;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            MarkedEvaluationDataGrid.Visibility = Visibility.Collapsed;

            markEvaluationForm.Visibility = Visibility.Visible;
            if (addBtn.Content.ToString() == "Add")
            {
                markEvaluationCC.Content = new MarkEvaluationFormUC();
                markEvaluationForm.Visibility = Visibility.Visible;
                MarkedEvaluationDataGrid.Visibility = Visibility.Collapsed;
                addBtn.Content = "Back";
            }
            else
            {
                DisplayMarkedEValuations();
                markEvaluationForm.Visibility = Visibility.Collapsed;
                MarkedEvaluationDataGrid.Visibility = Visibility.Visible;
                addBtn.Content = "Add";
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string GId, EvaluationName;
            int EId, OM, TM;
            DataRowView row = MarkedEvaluationDataGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                EId = Int32.Parse(row["EvaluationId"].ToString());
                GId = row["GroupId"].ToString();
                EvaluationName = row["Name"].ToString();
                TM = int.Parse(row["TotalMarks"].ToString());
                OM = int.Parse(row["ObtainedMarks"].ToString());
                markEvaluationCC.Content = new MarkEvaluationFormUC(GId, EvaluationName, EId, TM, OM);
                markEvaluationForm.Visibility = Visibility.Visible;
                MarkedEvaluationDataGrid.Visibility = Visibility.Collapsed;
                addBtn.Content = "Back";
            }
        }
    }
}
