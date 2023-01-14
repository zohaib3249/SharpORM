

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.DB
{
    public class Database: DatabaseBase
    {
        private static SqlDataReader reader;
        private static SqlDataAdapter adpt;
        private static DataTable data_table;
        public DataTable Execute(string sql)
        {
           
            try
            {
                connction_open();
                adpt = new SqlDataAdapter(sql, con);
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
