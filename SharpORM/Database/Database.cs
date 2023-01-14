using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpORM.Database
{
    public class Database:Helper
    {
        private static SqlDataReader reader;
        private static SqlDataAdapter adpt;
        private static DataTable data_table;
        public DataTable Execute(string sql)
        {

            try
            {
                connction_open();
                adpt = new SqlDataAdapter(sql, get_connection());
                data_table = new DataTable();
                adpt.Fill(data_table);
                connction_close();
            }
            catch (Exception ex)
            {
                log($"getting excetion {ex.ToString()}");
            }



            return data_table;
        }
    }
}
