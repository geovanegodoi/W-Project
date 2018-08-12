using System;

namespace SFC.Framework.Extensions
{
    internal static class TypeExtensions
    {
        public static short ToShort(this object obj)    
        {
            return Convert.ToInt16(obj);
        }

        public static int ToInteger(this object obj)    
        {
            return Convert.ToInt32(obj);
        }

        public static long ToLong(this object obj)      
        {
            return Convert.ToInt64(obj);
        }

        public static bool ToBoolean(this object obj)   
        {
            return ((string)obj == "1");
        }

        public static char ToChar(this object obj)      
        {
            return Convert.ToChar(obj);
        }
    }
}
