using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTry
{
    public sealed class DBConnection
    {
        SqlConnection conn;
        private static DBConnection instance = null;
        private DBConnection()
        {

        }

        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection();
                }
                return instance;
            }
        }

        public SqlConnection connect()
        {
            try
            {
                conn = new SqlConnection("Data Source=LAPTOP-L1OVUIF5;Initial Catalog=employeeManagement1;Integrated Security=True");
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return conn;
        }


    }
}
