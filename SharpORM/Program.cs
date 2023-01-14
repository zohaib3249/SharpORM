using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpORM;


namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Admin admin = new Admin();

            //admin.register_model(new User());
            admin.set_database("");
            admin.init();
        }
    }
}
