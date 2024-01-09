using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagment
{
    internal class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter Sda;
        private String ConStr;
        public Functions ()
        {
            ConStr = @"Data Source=SAHAR\SQLEXPRESS;Initial Catalog=RestaurantManagementSystem;Integrated Security=True";
            Con = new SqlConnection (ConStr);
            cmd = new SqlCommand();
            cmd.Connection = Con;
        }

        public DataTable GetData (string Query)
        {
            dt = new DataTable ();
            Sda = new SqlDataAdapter(Query, ConStr);
            Sda.Fill (dt);
            return dt;
        }

        public int SetData(string Query) 
        {
            int Cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery ();
            Con.Close();
            return Cnt;
        }

        }   
}
