using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpORM.Database;

namespace SharpORM
{
    public class Admin:Database.Database
    {
        public void init()
        {
            management mg = new management();
            mg.makemigrations();
        }

    }
}
