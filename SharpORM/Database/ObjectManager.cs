using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpORM.Database
{
    public class ObjectManager: Database
    {
        private DataTable _result_tale;
        public DataTable get_result_data_table()
        {
            return _result_tale;
        }
        public object get(params Func<object, object>[] args)
        {

            string get_query = get_sql_query_from_params(args);
            get_query = $"Select * from {_model} where " + get_query;

            _result_tale = this.Execute(get_query);
            Data_table_toObjects(_result_tale);
            return args;
        }
    }
}
