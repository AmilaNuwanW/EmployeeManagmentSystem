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
    public partial class AddEmp : Form
    {
        public AddEmp()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-L1OVUIF5;Initial Catalog=employeeManagement1;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            
        }
        private void populate()
        {
            conn.Open();
            string query = "select * from EmployeeTable";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            DGV.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void clear()
        {
            id.Clear();
            name.Clear();
            address.Clear();
            gender.Clear();
            possition.Clear();
            phoneNo.Clear();
            username.Clear();
            password.Clear();

        }
        
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            


        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.DGV.Rows[e.RowIndex];

                    id.Text = row.Cells["EmpID"].Value.ToString();
                    name.Text = row.Cells["EmpName"].Value.ToString();
                    address.Text = row.Cells["EmpAdd"].Value.ToString();
                    gender.Text = row.Cells["EmpAdd"].Value.ToString();
                    possition.Text = row.Cells["EmpPos"].Value.ToString();
                    phoneNo.Text = row.Cells["EmpPhone"].Value.ToString();
                    username.Text = row.Cells["EmpUName"].Value.ToString();
                    password.Text = row.Cells["EmpPwd"].Value.ToString();
                }


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

        private void AddEmp_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void AddBtn_Click_1(object sender, EventArgs e)
        {
            if (id.Text == "" || name.Text == "" || address.Text == "" || possition.Text == "" || phoneNo.Text == "" || username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Information Are Missing");
            }
            else
            {
                try
                {
                    conn.Open();



                    string query = "insert into EmployeeTable values ('" + id.Text + "','" + name.Text + "','" + address.Text + "','" + gender.Text + "','" + possition.Text + "','" + phoneNo.Text + "','" + dob.Value.Date + "','" + username.Text + "','" + password.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee successfully added");
                    conn.Close();
                    populate();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateBtn_Click_1(object sender, EventArgs e)
        {
            if (id.Text == "" || name.Text == "" || address.Text == "" || possition.Text == "" || phoneNo.Text == "" || username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Information Are Missing");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update EmployeeTable set EmpName='" + name.Text + "',EmpAdd='" + address.Text + "',EmpGen='" + gender.Text + "',EmpPos='" + possition.Text + "',EmpPhone='" + phoneNo.Text + "',EmpDOB='" + dob.Value.Date + "',EmpUName='" + username.Text + "',EmpPwd='" + password.Text + "' where EmpID='" + id.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee details are successfully upadated");
                    conn.Close();
                    populate();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("Please Enter Employee ID");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from EmployeeTable where EmpID='" + id.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee was successfully deleted");
                    conn.Close();
                    populate();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminHome().Show();
            this.Hide();
        }

        private void DGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id.Text = DGV.SelectedRows[0].Cells["EmpID"].Value.ToString();
                name.Text = DGV.SelectedRows[0].Cells["EmpName"].Value.ToString();
                address.Text = DGV.SelectedRows[0].Cells["EmpAdd"].Value.ToString();
                gender.Text = DGV.SelectedRows[0].Cells["EmpGen"].Value.ToString();
                possition.Text = DGV.SelectedRows[0].Cells["EmpPos"].Value.ToString();
                phoneNo.Text = DGV.SelectedRows[0].Cells["EmpPhone"].Value.ToString();
                dob.Text = DGV.SelectedRows[0].Cells["EmpDOB"].Value.ToString();
                username.Text = DGV.SelectedRows[0].Cells["EmpUName"].Value.ToString();
                password.Text = DGV.SelectedRows[0].Cells["EmpPwd"].Value.ToString();
            }
        }

        private void clearBtn_Click_1(object sender, EventArgs e)
        {
            clear();
        }
    }
}
