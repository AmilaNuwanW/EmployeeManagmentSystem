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
using SingletonTry;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class EmpDetails : Form
    {
        readonly SqlConnection conn;
        private string endEmpID;
        DBConnection db2 = DBConnection.Instance;
        string delid;
        int DelId;
        
        public EmpDetails(string endEmpID,string endUsername)
        {
            InitializeComponent();
            conn = db2.connect();
            //lblEmpid.Text = Login.EmpID + "";
            lblEmpid.Text = endEmpID.ToString();
            lblEmpName.Text = endUsername;
            Emptableleave(endEmpID);
        }

        public void Emptableleave(string empid)
        {
            string sql = "select * from Leave where EmployeeID = '"+empid+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string EmpId = lblEmpid.Text;
            string startdate = StartDate.Text;
            string enddate = EndDate.Text;
            string reason = txtReason.Text;
            string status = "Pending";

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Leave(EmployeeID,StartDate,EndDate,Reason,Status) values('"+EmpId+"','" +StartDate.Text+ "','"+EndDate.Text+ "','"+reason+"','"+status+"')", conn);
            cmd.ExecuteNonQuery();
            Emptableleave(EmpId);
            conn.Close();
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login1 = new Login();
            this.Hide();
            login1.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.RowIndex >= 0)
                {
                delid = dataGridView1.SelectedRows[0].Cells["LeaveID"].Value.ToString();
                if (delid != "")
                {
                    DelId = Int32.Parse(delid);
                }
                    
                }
            
            
            
        }

        private void btn_withdraw_Click(object sender, EventArgs e)
        {
            if (delid != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Leave where LeaveID = '" + DelId + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Withdraw successfull");
                Emptableleave(lblEmpid.Text);
                delid = "";
            }
            else
            {
                MessageBox.Show("Please select Leave Application");
            }
            
        }

        private void EmpDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
