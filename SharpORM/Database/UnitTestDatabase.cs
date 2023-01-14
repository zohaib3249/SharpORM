using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;


namespace SharpORM.Database
{
    internal class UnitTestDatabase : DatabaseInit
    {


        public bool test_conection()
        {
            try
            {
                get_connection().Open();
                get_connection().Close();
                return true;
            }
            catch (Exception ex)
            {
                log($"Server connection is not responding or may wrong server address");
                log(ex.ToString());
                return false;
            }



        }

        public bool test_database()
        {
            string query = "SELECT COUNT(*) FROM sys.databases WHERE name = 'pos'";
            connction_open();
            SqlCommand command = new SqlCommand(query, get_connection());
            int count = (int)command.ExecuteScalar();
            connction_close();
            if (count > 0)
            {
              
                
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool test_tabels()
        {
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG='pos'";
            List<string> tableNames = new List<string>();


            connction_open();
            SqlCommand command = new SqlCommand(query, get_connection());


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = reader.GetString(reader.GetOrdinal("name"));
                    tableNames.Add(tableName);
                }
            }
            
            connction_close();
            return false;
        }



    }
}
