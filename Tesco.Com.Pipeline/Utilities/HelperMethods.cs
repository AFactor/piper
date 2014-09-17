using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (!string.IsNullOrEmpty(data))
            {
                Dictionary<string, string> dic = data.Split(separator).Select(s => s.Split('=')).ToDictionary(a => a[0], a => a[1]);
                if (dic.ContainsKey(key))
                {
                    value = dic[key];
                }
            }
            return value;
        }

        /// <summary>
        /// Convert Foreign Accent Characters
        /// </summary>
        /// 
        /// <returns>Common ASCII representation</returns>
        public static string RemoveAccent(this string s)
        {
            return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(s));
        }

        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9/_\s-]", "");

            str = Regex.Replace(str, @"[/_]", " ").Trim();

            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();

            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        } 
    }
}