using System;

namespace SchoolApp.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute:Attribute
    {
        public TableAttribute(string schema, string table)
        {
            Schema = schema;
            Table = table;
        }
        public string Schema { get; set; }
        public string Table { get; set; }
    }
}