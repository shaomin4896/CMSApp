using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CaseManagementApp.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsAnyNullOrEmpty(this object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                Type t = pi.PropertyType;
                object? value = pi.GetValue(myObject);
                if (t.IsPrimitive || t == typeof(Decimal) || t == typeof(String))
                    if (value == null) return true;
                else return IsAnyNullOrEmpty(value);
            }
            return false;
        }
    }
}