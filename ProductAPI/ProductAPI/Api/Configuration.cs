/*
 <apis>
  <apilist>
  <api name="Product" verb="get" type="Tesco.Com.AppStore.Product.SimplePagedProducts" typeAssembly="Tesco.Com.AppStore.Product.Contracts" uri ="http://localhost:105/ProductApi/api/Products/Search/query={0}/required={1}/region={2}/language={3}/storeid={4}/sort={5}/facets=all/page={6}"/>
  </apilist>
</apis>
 */
using System.Configuration;
using System.Collections.Generic;
using System;

namespace ProductAPI.Api
{
    #region Custom Configuration Elements

    /// <summary>
    /// Custom content security configuration section
    /// </summary>
    public class ApisSection : ConfigurationSection
    {
        /// <summary>
        /// settings collection
        /// </summary>
        [ConfigurationProperty("providers")]
        [ConfigurationCollection(typeof(ConfigurationCollection<ProviderConfigurationElement>), AddItemName = "provider")]
        public ConfigurationCollection<ProviderConfigurationElement> Providers
        {
            get { return (ConfigurationCollection<ProviderConfigurationElement>)base["providers"]; }
        }

    }

    public class ProviderConfigurationElement: ConfigurationElement, IKey
    {
        /// <summary>
        /// Name attribute, eg 'GAPI/TAPI'
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return Convert.ToString(this["name"]); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("apilist")]
        [ConfigurationCollection(typeof(ConfigurationCollection<ApiConfigurationElement>), AddItemName = "api")]
        public ConfigurationCollection<ApiConfigurationElement> ApiList
        {
            get { return (ConfigurationCollection<ApiConfigurationElement>)base["apilist"]; }
        }
        object IKey.Key
        {
            get { return this.Name; }
        }
    }

    /// <summary>
    /// Api configuration element (child of "api"s collection)
    /// </summary>
    public class ApiConfigurationElement : ConfigurationElement, IKey
    {
        /// <summary>
        /// Name attribute, eg 'Product' / 'Customer'
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return Convert.ToString(this["name"]); }
            set { this["name"] = value; }
        }

         /// <summary>
        /// Type attribute, eg SimpleProduct
        /// </summary>
        [ConfigurationProperty("type", IsKey = false, IsRequired = true)]
        public string Type
        {
            get { return Convert.ToString(this["type"]); }
            set { this["type"] = value; }
        }

        /// <summary>
        /// uri attribute, eg "http://ProductAPi/Product"
        /// </summary>
        [ConfigurationProperty("uri", IsKey = false, IsRequired = true)]
        public string Uri
        {
            get { return Convert.ToString(this["uri"]); }
            set { this["uri"] = value; }
        }

        /// <summary>
        /// verb attribute, eg get, put, post
        /// </summary>
        [ConfigurationProperty("verb", IsKey = false, IsRequired = true)]
        public string Verb
        {
            get { return Convert.ToString(this["verb"]); }
            set { this["verb"] = value; }
        }

        /// <summary>
        /// The assembly the type  belongs to.
        /// </summary>
        [ConfigurationProperty("typeAssembly", IsKey = false, IsRequired = true)]
        public string TypeAssembly
        {
            get { return Convert.ToString(this["typeAssembly"]); }
            set { this["typeAssembly"] = value; }
        }

        /// <summary>
        /// The number of query parameters required
        /// </summary>
        [ConfigurationProperty("paramCount", IsKey = false, IsRequired = true)]
        public int ParamCount
        {
            get { return Convert.ToInt32(this["paramCount"]); }
            set { this["paramCount"] = value; }
        }

        /// <summary>
        /// Is return type generic
        /// </summary>
        [ConfigurationProperty("isGeneric", IsKey = false, IsRequired = true)]
        public bool IsGeneric
        {
            get { return Convert.ToBoolean(this["isGeneric"]); }
            set { this["paramCount"] = value; }
        }


        object IKey.Key
        {
            get { return this.Name; }
        }

    }


    #endregion

    #region Generic ConfigurationCollection

    public interface IKey
    {
        object Key { get; }
    }

    public class ConfigurationCollection<T> : ConfigurationElementCollection where T : ConfigurationElement, IKey, new()
    {
        public ConfigurationCollection()
        {
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((T)element).Key;
        }
        public T this[int index]
        {
            get { return (T)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }
        new public T this[string name]
        {
            get { return (T)BaseGet(name.ToLowerInvariant()); }
        }
        public int IndexOf(T element)
        {
            return BaseIndexOf(element);
        }
        public void Add(T element)
        {
            BaseAdd(element);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            base.BaseAdd(element, false);
        }
        public void Remove(T element)
        {
            if (BaseIndexOf(element) > 0)
                BaseRemove(element.Key);
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        public void Remove(string type)
        {
            BaseRemove(type);
        }
        public void Clear()
        {
            BaseClear();
        }
    }

    #endregion
}