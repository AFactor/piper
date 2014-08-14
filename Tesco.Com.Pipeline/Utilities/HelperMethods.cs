using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Utilities
{
    public static class HelperMethods
    {
        public static Object CreateGeneric(Type generic, Type innerType)
        {
            System.Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
            return Activator.CreateInstance(specificType);
        }

        public static string Extract(string data, string key, char separator)
        {
            string value = string.Empty;
            Dictionary<string, string> dic = data.Split(separator).Select(s => s.Split('=')).ToDictionary(a => a[0], a => a[1]);
            if (dic.ContainsKey(key))
            {
                value = dic[key];
            }
            return value;
        }
    }
}   