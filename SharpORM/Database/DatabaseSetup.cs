using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;


namespace SharpORM.Database
{
    internal class DatabaseSetup : DatabaseInit
    {
        protected bool create_table(string table)
        {
            Console.WriteLine(table);
            try
            {
                connction_open();
                using (SqlCommand command = new SqlCommand(table, get_connection()))
                {

                    command.ExecuteNonQuery();
                }
                connction_close();
                return true;
            }
            catch (Exception ex)
            {
                log($"There is an error during creation of table in database");
                log(ex.ToString());

                connction_close();
                return false;
            }

        }
        public bool create_tables()
        {

            List<string> list_of_tables = new List<string>();
           
            list_of_tables = _models_list;

            try
            {
                foreach (string table in list_of_tables)
                {
                    create_table(table);
                }
                return true;
            }
            catch (Exception ex)
            {
                log($"There is an error during creation of table in database");
                log(ex.ToString());
                return false;
            }


        }
        public bool create_databae()
        {
            string queryString = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = @databaseName) BEGIN CREATE DATABASE @databaseName END";

            try
            {
                connction_open();

                using (SqlCommand command = new SqlCommand(queryString, get_connection()))
                {

                    command.ExecuteNonQuery();
                }
                connction_close();

                UnitTestDatabase udb = new UnitTestDatabase();
                return udb.test_conection();
            }
            catch (Exception ex)
            {
                log($"There is an error during creation of database");
                log(ex.ToString());
                connction_close();
                return false;
            }
        }
    }
}
