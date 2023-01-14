using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using Microsoft.Data.Sqlite;
using System.Data;

namespace DXApplication1.DB
{
    public class DatabaseBase: Logs
    {
        protected static readonly string connection_string = "Server=DESKTOP-T4Q7ET8;Database=pos;Trusted_Connection=True;";
        protected static readonly SqlConnection con = new SqlConnection(connection_string);
        protected static SqlCommand cmd = new SqlCommand("", con);
        
        
        protected void connction_open()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

        }

        protected void connction_close()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }
        
    }
}
