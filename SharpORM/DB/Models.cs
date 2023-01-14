using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Windows;
using System.ComponentModel;
using DevExpress.XtraEditors.Filtering.Templates;

namespace DXApplication1.DB
{




    internal class Models : Model_properties
    {

        public Models()
        {
            // make sure to add tables here
            models_list.Clear();
            // table sequence is Importent
            models_list.Add(new Test());
            models_list.Add(new Testngs());
            models_list.Add(new Users());
            models_list.Add(new Settings());



        }


        internal class Test:ObjectManager
        {
            public int ids { get; set; }
            [IsNullALlowed(false)]
            [IsUnique(true)]
            public int name { get; set; }
            public void test_user()
            {
                this.get(ids => 1);

            }

        }
        class Testngs: ObjectManager
        {
           
            [IsNullALlowed(false)]
            [IsUnique(true)]
            public int name { get; set; }
            
            
        }

        internal class Users: ObjectManager
        {

            public int id { get; set; }
            public string name { get; set; }
            //[DefaultValue("dd")]
            [IsNullALlowed(false)]
            [IsUnique(true)]
            public string passwod { get; set; }

            [ForignKey("Test","ids")]
            public int test_id { get; set; }

            
           
            

        }
        internal class Settings
        {
            public int id { get; set; }
            public string shop_name { get; set; }
            public string address { get; set; }
            public string phone_number { get; set; }
            public string email { get; set; }
            

        }


    }
}
