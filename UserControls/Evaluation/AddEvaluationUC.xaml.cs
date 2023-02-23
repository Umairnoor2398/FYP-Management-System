﻿using CRUD_Operations;
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

        private void revertBtn_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtTotalMarks.Clear();
            txtTotalWeightage.Clear();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
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
                    MessageBox.Show(ex.Message);
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
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}