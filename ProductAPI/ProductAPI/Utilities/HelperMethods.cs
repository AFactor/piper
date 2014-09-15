using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Runtime.Remoting;
namespace ProductAPI.Utilities
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