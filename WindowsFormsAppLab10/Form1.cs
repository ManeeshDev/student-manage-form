using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppLab10
{
    public partial class Form1 : Form
    {

        String conString;
        SqlConnection con;

        int studentID;
        String studentName;
        int age;
        double gpa;
        String address;
        
        public Form1()
        {
            InitializeComponent();
        }

        public string getConnectionString()
        {
            string conString;

            conString = @"Data Source=MANEESH-ASUS-TU\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";


            return conString;
        }

        public void loadData()
        {
            conString = getConnectionString();
            con = new SqlConnection(conString);
            con.Open();
            String sql = "SELECT * FROM dbo.Student";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con);

            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            studentTableView.DataSource = table;

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                conString = getConnectionString();

                con = new SqlConnection(conString);
                con.Open();

                if ((txtStName.Text == "" || txtStName.Text == null) && (txtStID.Text == "" || txtStID.Text == null) &&
                    (txtAge.Text == "" || txtAge.Text == null) && (txtGpa.Text == "" || txtGpa.Text == null) &&
                    (txtAddress.Text == "" || txtAddress.Text == null))
                {
                    MessageBox.Show("Please fill all fields!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                studentName = txtStName.Text;
                studentID = Int32.Parse(txtStID.Text);
                age = Int32.Parse(txtAge.Text);
                gpa = Convert.ToDouble(txtGpa.Text);
                address = txtAddress.Text;

                string insertQuery = "INSERT INTO dbo.Student VALUES (@studentID, @studentName, @age, @gpa, @address)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@studentID", studentID);
                insertCmd.Parameters.AddWithValue("@studentName", studentName);
                insertCmd.Parameters.AddWithValue("@age", age);
                insertCmd.Parameters.AddWithValue("@gpa", gpa);
                insertCmd.Parameters.AddWithValue("@address", address);

                insertCmd.ExecuteNonQuery();

                con.Close();

                txtStName.Text = "";
                txtStID.Text = "";
                txtAge.Text = "";
                txtGpa.Text = "";
                txtAddress.Text = "";

                MessageBox.Show("Successfully Saved..", " Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

    }
}
