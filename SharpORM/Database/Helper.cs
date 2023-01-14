using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SharpORM.Database
{
    public class DynamicObject
    {
        public string name { get; set; }
        public object value { get; set; }
        public DynamicObject(string _name, object _value)
        {
            name = _name;
            value = _value;


        }
    }
    public class Helper:DatabaseInit
    {
        public List<string> _params_list = new List<string>();
        public string _model = null;
        public object _model_obj = null;
        
        

        public dynamic Data_table_toObjects(DataTable dt)
        {

            Type classType = Type.GetType(_model);
            _model_obj = Activator.CreateInstance(classType);
            foreach (DataRow row in dt.Rows)
            {
                log(row.ToString());
            }
            return "";
        }
        public List<DynamicObject> Get_Dynamic_List(Func<object, object>[] args)
        {
            List<DynamicObject> _list = new List<DynamicObject>();
            foreach (var arg in args)
            {

                var name = (arg.Method.GetParameters()[0]).Name;
                var val = arg.Invoke(null);
                DynamicObject dob = new DynamicObject(name, val);
                _list.Add(dob);
                _params_list.Add(name);
            }
            return _list;

        }
        public List<string> get_object_properties()
        {

            Type type = this.GetType();
            _model = type.Name;
            PropertyInfo[] properties = type.GetProperties();
            List<string> _propames = new List<string>();
            foreach (var prop in properties)
            {
                _propames.Add(prop.Name);
            }
            return _propames;
        }
        public bool check_properties()
        {
            List<string> Oject_properties = get_object_properties();
            var check_if_valid_params = _params_list.Intersect(Oject_properties).Count() == _params_list.Count();
            return check_if_valid_params;
        }
        public string get_sql_query_from_params(Func<object, object>[] args)
        {

            string query = " ";
            List<DynamicObject> listOfParam = Get_Dynamic_List(args);
            if (check_properties())
            {
                foreach (var ob in listOfParam)
                {


                    query = query + ob.name + " = " + ob.value + " ";
                    if (ob != listOfParam.Last())
                    {
                        query = query + "AND ";
                    }

                }
                return query;

            }
            else
            {
                //
                log("Ivalid Parametrs passed Please check parametes name on model");
                new System.Exception("Ivalid Parametrs passed Please check parametes name on model");
                return query;
            }


        }
    }

    
}
