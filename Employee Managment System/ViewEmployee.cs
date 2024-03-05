using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-L1OVUIF5;Initial Catalog=employeeManagement1;Integrated Security=True");

        private void clear()
        {
            idLbl.Text = "";
            nameLbl.Text = "";
            addressLbl.Text = "";
            genderLbl.Text = "";
            positionLbl.Text = "";
            phoneLbl.Text = "";
            dobLbl.Text = "";
            usernameLbl.Text = "";
            eid.Text = "";

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "select * from EmployeeTable where EmpID='" + eid.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    idLbl.Text = dr["EmpID"].ToString();
                    nameLbl.Text = dr["EmpName"].ToString();
                    addressLbl.Text = dr["EmpAdd"].ToString();
                    genderLbl.Text = dr["EmpGen"].ToString();
                    positionLbl.Text = dr["EmpPos"].ToString();
                    phoneLbl.Text = dr["EmpPhone"].ToString();
                    dobLbl.Text = dr["EmpDOB"].ToString();
                    usernameLbl.Text = dr["EmpUName"].ToString();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminHome().Show();
            this.Hide();
        }
    }
}
