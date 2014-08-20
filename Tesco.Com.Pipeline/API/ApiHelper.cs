using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.API
{
    public class ApiHelper
    {
        private static ApisSection apisConfigurationSection = null;
        public static ApisSection ApisConfigurationSection
        {
            get
            {
                if (apisConfigurationSection == null)
                {
                    apisConfigurationSection = (ApisSection)ConfigurationManager.GetSection("apis");
                }
                return apisConfigurationSection;
            }
        }

        public static ApiConfigurationElement GetApiForKey(string name, string provider)
        {
            //var a=new ApiConfigurationElement();  
            //return a;
            var apisSection = ApisConfigurationSection;
            if (apisSection.Providers[provider] != null)
            {

                foreach (ApiConfigurationElement apiElement in apisSection.Providers[provider].ApiList)
                {
                    if (name == apiElement.Name)
                        return apiElement;
                }

            }
            return null;
        }
    }
}