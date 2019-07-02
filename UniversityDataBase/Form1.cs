using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace UniversityDataBase
{
    public partial class Form1 : Form
    {
        private String connectionString;
        private SqlConnection newConnection;
        private String query;
       
        public Form1()
        {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\University.mdf;Integrated Security=True";
        }

        private void Go_Button_Click(object sender, EventArgs e)
        {
            try
            {
                query = textBox1.Text;
                SelectedOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectedOption()
        {
            if (radioButton1.Checked)
            {
                Add();
            }
            else if (radioButton2.Checked)
            {
                Delete();
            }
            else if (radioButton3.Checked)
            {
                Edit();
            }
            else if (radioButton4.Checked)
            {
                dataGridView1.DataSource = Select();
            }
        }

        private void Add()
        {
            try
            {
                using (newConnection = new SqlConnection(connectionString))
                {
                    newConnection.Open();
                    SqlCommand newCommand = new SqlCommand(query, newConnection);
                    newCommand.ExecuteNonQuery();
                    newConnection.Close();
                    MessageBox.Show("Record Added!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete()
        {

            try
            {
                using (newConnection = new SqlConnection(connectionString))
                {
                    newConnection.Open();
                    SqlCommand newCommand = new SqlCommand(query, newConnection);
                    newCommand.ExecuteNonQuery();
                    newConnection.Close();
                    MessageBox.Show("Record Deleted!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit()
        {

            try
            {
                using (newConnection = new SqlConnection(connectionString))
                {
                    newConnection.Open();
                    SqlCommand newCommand = new SqlCommand(query, newConnection);
                    newCommand.ExecuteNonQuery();
                    newConnection.Close();
                    MessageBox.Show("Record Updated!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable Select()
        {

            try
            {
                DataTable newTable = null;
                using (newConnection = new SqlConnection(connectionString))
                {
                    newConnection.Open();
                    SqlCommand newCommand = new SqlCommand(query, newConnection);
                    SqlDataAdapter newAdapter = new SqlDataAdapter(newCommand);
                    newTable = new DataTable();
                    newAdapter.Fill(newTable);
                    newConnection.Close();
                }
                return newTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
