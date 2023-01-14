using DevExpress.Internal.WinApi;
using DevExpress.Utils;
using DevExpress.Utils.Win.Hook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq.Expressions;


namespace DXApplication1.DB
{

   



    
    internal class Model_properties:Decorators
    {
        Dictionary<string, string> data_properties =
                        new Dictionary<string, string>();
        public static List<object> models_list = new List<object>();
        public Model_properties()
        {
            data_properties.Add("System.Int32", "int");
            data_properties.Add("System.String", "varchar(255)");
            data_properties.Add("System.Bool", "tinyint");
            data_properties.Add("System.DateTime", "datetime default CURRENT_TIMESTAMP");
            data_properties.Add("Decimal", "decimal(18, 0)");
            data_properties.Add("Date", "Date");
           
        }
        public List<string> ge_table_names()
        {
            List<string> list = new List<string>();
            foreach (var model in models_list)
            {

                Type type = model.GetType();
                list.Add(type.Name);
            }
            return list;
        }
        public string get_property_value(string name)
        {
            try
            {
                return data_properties[name];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), caption: "Error");

                return data_properties["string"];
            }
        }
        public List<string> get_tables()
        {
            List<string> tables = new List<string>();
            foreach (var model in models_list)
            {
                Type type = model.GetType();
                PropertyInfo[] properties = type.GetProperties();
                string table_start = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='" + type.Name + "' and xtype='U')" +
                    " CREATE TABLE " + type.Name + "(";
                string table = "";
                bool isPrimaryKeyExist=false;
                
                var match = properties
                        .FirstOrDefault(property => property.Name.Contains("id"));

                foreach (PropertyInfo property in properties)
                {
                    if (property==match)
                    {
                        continue;
                    }

                    table = table + " " + property.Name + " " + get_property_value(property.PropertyType.ToString());
                    List<string> list_ofProp= get_propeties(property);
                    table = table + list_ofProp[0];
                    isPrimaryKeyExist = bool.Parse(list_ofProp[1]);
                    
                    if (property != properties.Last())
                    {
                        table = table + ",";
                    }

                }
                if (isPrimaryKeyExist==false && match!=null)
                {
                    string id= match.Name + " " + get_property_value(match.PropertyType.ToString());
                    List<string> list_ofProp = get_propeties(match);
                    table =  id+" "+ list_ofProp[0]+ " IDENTITY(1,1) PRIMARY KEY ,"+table;
                }
                else
                {
                    string id = "id int NOT NULL  IDENTITY(1,1) PRIMARY KEY,  ";
                    table = id + table;
                }
               
                table = table_start+table + ")";
                tables.Add(table);
            }
            return tables;
        }

        protected List<string> get_propeties(PropertyInfo property)
        {
            object[] attrs = property.GetCustomAttributes(true);
            string properties = " ";
            bool is_primaryKey = false;
            List<string> output = new List<string>();
            foreach (dynamic attr in attrs)
            {
                if (attrs.GetType().ToString()== "PrimaryKey")
                {
                    is_primaryKey = true;
                }


                if (attr != null)
                {
                
                    properties = properties+ attr.Value;
                   
                }
            }
            output.Add(properties);
            output.Add(is_primaryKey.ToString());
            return output;
            /*
             string table = "";
            //DefaultValueAttribute attribute = (DefaultValueAttribute)property.GetCustomAttribute(typeof(DefaultValueAttribute));

            ForignKey fattribute = (ForignKey)Attribute.GetCustomAttribute(property, typeof(ForignKey));
            IsUnique Isunique = (IsUnique)Attribute.GetCustomAttribute(property, typeof(IsUnique));
            if (property.Name == "id")
            {
                table = table + " IDENTITY(1,1) PRIMARY KEY";
            }
            
             if (attribute != null && property.Name != "id")
            {
                object defaultValue = attribute.Value;
                table = table + " default " + defaultValue;
            }
             
            if (fattribute != null)
            {
                string model_nme = fattribute.Value;
                if (model_nme != null)
                {
                    table = table + " FOREIGN KEY REFERENCES " + model_nme + "(id)";
                }
            }
            if (Isunique != null)
            {
                string isunique = Isunique.Value;
                if (isunique != null)
                {
                    table = table + isunique;
                }
            }
            */
           
        }



    }



}




