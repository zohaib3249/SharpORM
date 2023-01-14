using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpORM.Database
{
    internal class Decorators:DatabaseInit
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class ForeignKey : Attribute
        {
            public ForeignKey(string value, string id)
            {
                Value = " FOREIGN KEY REFERENCES " + value + "(" + id + ")";
            }

            public string Value { get; }
        }
        public class Default : Attribute
        {
            public Default(string value)
            {
                Value = value;
            }

            public string Value { get; }
        }
        public class isRequired : Attribute
        {
            public isRequired(bool value)
            {
                if (value)
                {
                    Value = " NULL ";
                }
                else
                {
                    Value = " NOT NULL ";
                }

            }

            public string Value { get; }
        }
        public class IsUnique : Attribute
        {
            public IsUnique(bool value)
            {
                if (value)
                {
                    Value = " UNIQUE ";
                }
                else
                {
                    Value = "";
                }

            }

            public string Value { get; }
        }
        public class PrimaryKey : Attribute
        {
            public PrimaryKey(bool value)
            {
                if (value)
                {
                    Value = " IDENTITY(1,1) PRIMARY KEY ";
                }
                


            }

            public string Value { get; }
        }
    }
}
