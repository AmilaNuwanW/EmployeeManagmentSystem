using SingletonTry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ManageLeave : Form
    {
        SqlConnection conn;
        DBConnection db3 = DBConnection.Instance;
        public ManageLeave()
        {
            InitializeComponent();
            conn = db3.connect();
            allleave();

        }

        public void allleave()
        {
            string sql = "select * from Leave";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        public void filteredleave()
        {
            string filterval = filter.GetItemText(filter.SelectedItem);
            if (filterval == "All")
            {
                allleave();
            }
            else
            {
                string sql = "select * from Leave where Status = '" + filterval + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filteredleave();
            lblLeaveID.Text = "";
            lblEmployeeID.Text = "";
            lblStartDate.Text = "";
            lblEndDate.Text = "";
            lblReason.Text = "";
            lblStatus.Text = "";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblLeaveID.Text = dataGridView2.SelectedRows[0].Cells["LeaveID"].Value.ToString();
                lblEmployeeID.Text = dataGridView2.SelectedRows[0].Cells["EmployeeID"].Value.ToString();
                lblStartDate.Text = dataGridView2.SelectedRows[0].Cells["StartDate"].Value.ToString();
                lblEndDate.Text = dataGridView2.SelectedRows[0].Cells["EndDate"].Value.ToString();
                lblReason.Text = dataGridView2.SelectedRows[0].Cells["Reason"].Value.ToString();
                lblStatus.Text = dataGridView2.SelectedRows[0].Cells["Status"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblLeaveID.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Leave set Status = '"+ "Approved" + "' where LeaveID = '"+lblLeaveID.Text+"'",conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Approved");
                lblStatus.Text = "Approved";
                allleave();
            }
            else
            {
                MessageBox.Show("Please select a leave application record");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblLeaveID.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Leave set Status = '" + "Rejected" + "' where LeaveID = '" + lblLeaveID.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Rejected");
                lblStatus.Text = "Rejected";
                allleave();
            }
            else
            {
                MessageBox.Show("Please select a leave application record");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}
