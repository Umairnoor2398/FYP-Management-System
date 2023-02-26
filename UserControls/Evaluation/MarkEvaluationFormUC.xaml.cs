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
using System.Drawing;

namespace ProjectA.UserControls.Evaluation
{
    /// <summary>
    /// Interaction logic for MarkEvaluationFormUC.xaml
    /// </summary>
    public partial class MarkEvaluationFormUC : UserControl
    {
        int evaluationId, groupId;
        public MarkEvaluationFormUC()
        {
            InitializeComponent();
            GroupToComboBox();
            EvaluationToComboBox();
            addBtn.Content = "Add";
        }
        public MarkEvaluationFormUC(string groupId, string evaluationName, int evaluationId, int totalMarks, int obtainedMarks)
        {
            InitializeComponent();
            GroupToComboBox();
            EvaluationToComboBox();
            addBtn.Content = "Update";
            GroupComboBox.Text = groupId;
            EvaluationComboBox.Text = evaluationName;
            totalMarkstxtBlock.Text = totalMarks.ToString();
            txtObtainedMarks.Text = obtainedMarks.ToString();
            this.evaluationId = evaluationId;
            //this.groupId = int.Parse(groupId);
            string[] GId = groupId.Split('-');
            this.groupId = int.Parse(GId[1]);
            GetSelectedEvaluationId(evaluationName);
            GroupComboBox.IsEnabled = false;
            EvaluationComboBox.IsEnabled = false;
        }

        private void GroupToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select CONCAT('G-',Id) AS Id From [Group]", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            GroupComboBox.ItemsSource = dt.Tables[0].DefaultView;
            GroupComboBox.DisplayMemberPath = "Id";
        }

        private void EvaluationToComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name From Evaluation", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            d.Fill(dt);
            EvaluationComboBox.ItemsSource = dt.Tables[0].DefaultView;
            EvaluationComboBox.DisplayMemberPath = "Name";
        }
        private void GetSelectedEvaluationId(string name)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id,TotalMarks FROM Evaluation WHERE Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                evaluationId = int.Parse(reader["Id"].ToString());
                totalMarkstxtBlock.Text = reader["TotalMarks"].ToString();
            }
            reader.Close();
        }
        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addBtn.Content.ToString() == "Add")
            {
                GroupComboBox.Text = string.Empty;
                EvaluationComboBox.Text = string.Empty;
                txtObtainedMarks.Text = string.Empty;
                totalMarkstxtBlock.Text = "0";
            }
            else
            {
                txtObtainedMarks.Text = string.Empty;
            }
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (sender.Equals(EvaluationComboBox))
            {
                GetSelectedEvaluationId(EvaluationComboBox.Text);
            }
            else
            {
                if (GroupComboBox.Text != string.Empty)
                {
                    string[] GId = GroupComboBox.Text.Split('-');
                    this.groupId = int.Parse(GId[1]);
                }
                else
                {
                    groupId = 0;
                }

            }
        }

        private void findParentControls()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while ((parent != null) && !(parent is MarkEvaluationDisplayUC))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent is MarkEvaluationDisplayUC)
            {
                MarkEvaluationDisplayUC markEvaluation = (MarkEvaluationDisplayUC)parent;
                markEvaluation.DisplayMarkedEValuations();
                Button btn = (Button)markEvaluation.FindName("addBtn");
                DataGrid MarkedEvaluationDataGrid = (DataGrid)markEvaluation.FindName("MarkedEvaluationDataGrid");
                btn.Content = "Add";
                MarkedEvaluationDataGrid.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GroupComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please Select A Group to evaluate", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (EvaluationComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please Select Evaluation Title to evaluate", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtObtainedMarks.Text == string.Empty)
            {
                MessageBox.Show("A Group cannot be assigned null marks in any evaluation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (int.Parse(txtObtainedMarks.Text) > int.Parse(totalMarkstxtBlock.Text))
            {
                MessageBox.Show("Obtained Marks cannot be greater than total marks", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (addBtn.Content.ToString() == "Add")
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("INSERT INTO GroupEvaluation VALUES (@GroupId,@EvaluationId,@ObtainedMarks, @Date)", con);
                        cmd.Parameters.AddWithValue("@GroupId", groupId);
                        cmd.Parameters.AddWithValue("@EvaluationId", evaluationId);
                        cmd.Parameters.AddWithValue("@ObtainedMarks", int.Parse(txtObtainedMarks.Text));
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
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
                        SqlCommand cmd = new SqlCommand("UPDATE GroupEvaluation SET ObtainedMarks = @ObtainedMarks, EvaluationDate=@Date WHERE GroupId=@GroupId AND EvaluationId=@EvaluationId", con);
                        cmd.Parameters.AddWithValue("@GroupId", groupId);
                        cmd.Parameters.AddWithValue("@EvaluationId", evaluationId);
                        cmd.Parameters.AddWithValue("@ObtainedMarks", int.Parse(txtObtainedMarks.Text));
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
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
