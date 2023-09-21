using SingletonTry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        readonly SqlConnection conn;
        DBConnection db1 = DBConnection.Instance;

        public Login()
        {
            InitializeComponent();
            conn = db1.connect();

        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from  EmployeeTable where EmpUName='" + txtUsername.Text + "' and EmpPwd='" + txtPassword.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i == 1)
                {
                    String EmpID = (string)ds.Tables[0].Rows[0]["EmpID"];
                    string Username = (string)ds.Tables[0].Rows[0]["EmpName"];

                    EmpDetails ed = new EmpDetails(EmpID, Username);
                    this.Hide();
                    ed.Show();
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("select * from  Admin where Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'", conn);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    int j = ds1.Tables[0].Rows.Count;
                    if (j == 1)
                    {
                        new AdminHome().Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Login error! Invalid username or password.");
                    }
                }
                conn.Close();
            }

            catch(SqlException ex)
            {
                MessageBox.Show("An error occurred while executing the SQL query: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
