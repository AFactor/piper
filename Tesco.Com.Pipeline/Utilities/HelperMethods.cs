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
    }
}   