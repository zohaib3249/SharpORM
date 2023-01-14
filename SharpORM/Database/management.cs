using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpORM.Database
{
    internal class management:Database
    {
        public void makemigrations()
        {
            UnitTestDatabase ut=new UnitTestDatabase();
            if(ut.test_conection())
            {
                DatabaseSetup obj = new DatabaseSetup();
                obj.create_tables();
            }
            else
            {
                log("Database Connection problem,please make sure you provided Server string before init set");
                throw new Exception("Database Connection problem,please make sure you provided Server string before init set");
            }
            
        }
    }
}
