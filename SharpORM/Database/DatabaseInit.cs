using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace SharpORM.Database
{
    public class DatabaseInit:Logs
    {
        private static readonly string connection_string1 = "Server=DESKTOP-T4Q7ET8;Database=pos;Trusted_Connection=True;";
        
        private static string _connection_string="";
        protected static List<string> _models_list = new List<string>();
        
        

        protected SqlConnection get_connection()
        { 
            if (_connection_string!=null)
            {
                SqlConnection con = new SqlConnection(_connection_string);
                return con;
            }
            else
            {
                log("Server Connection not avaliable");
                throw new Exception("Server Connection not avaliable");
               
            }
           
        }
        public void set_database(string databaseConnection)
        {
            _connection_string = databaseConnection;
        }
        public void register_model(string model)
        {
            _models_list.Add(model);
        }
        private string get_database()
        {
            return _connection_string;
        }
        protected void connction_open()
        {
            SqlConnection con = get_connection();
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

        }

        protected void connction_close()
        {
            SqlConnection con = get_connection();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }

    }
}
