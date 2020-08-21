using System;
using System.Reflection;

namespace SchoolApp.DataLayer
{
    class PropertyModel
    {
        public bool IsIdentity { get; set; }
        public string PropertyName { get; set; }
        public string ColumnName { get; set; }
        public bool IsPrimeryKey { get; set; }
        public bool IsComputed { get; set; }
        public PropertyInfo Propertyinfo { get; set; }
    }
}
