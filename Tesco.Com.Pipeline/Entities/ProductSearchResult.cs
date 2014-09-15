using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ProductSearchResult
    {

        private ProductSearchResultProduct[] resultsField;

        private ushort totalMatchedCountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Product", IsNullable = false)]
        public ProductSearchResultProduct[] Results
        {
            get
            {
                return this.resultsField;
            }
            set
            {
                this.resultsField = value;
            }
        }

        /// <remarks/>
        public ushort TotalMatchedCount
        {
            get
            {
                return this.totalMatchedCountField;
            }
            set
            {
                this.totalMatchedCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProduct
    {

        private uint productIdField;

        private ProductSearchResultProductIdentifiers identifiersField;

        private ProductSearchResultProductSummary summaryField;

        private ProductSearchResultProductProductMediaContent[] mediaField;

        private ProductSearchResultProductProductAttribute[] customAttributesField;

        /// <remarks/>
        public uint ProductId
        {
            get
            {
                return this.productIdField;
            }
            set
            {
                this.productIdField = value;
            }
        }

        /// <remarks/>
        public ProductSearchResultProductIdentifiers Identifiers
        {
            get
            {
                return this.identifiersField;
            }
            set
            {
                this.identifiersField = value;
            }
        }

        /// <remarks/>
        public ProductSearchResultProductSummary Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ProductMediaContent", IsNullable = false)]
        public ProductSearchResultProductProductMediaContent[] Media
        {
            get
            {
                return this.mediaField;
            }
            set
            {
                this.mediaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ProductAttribute", IsNullable = false)]
        public ProductSearchResultProductProductAttribute[] CustomAttributes
        {
            get
            {
                return this.customAttributesField;
            }
            set
            {
                this.customAttributesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductIdentifiers
    {

        private uint baseProductIdField;

        /// <remarks/>
        public uint BaseProductId
        {
            get
            {
                return this.baseProductIdField;
            }
            set
            {
                this.baseProductIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummary
    {

        private uint baseProductIdField;

        private string descriptionField;

        private string titleField;

        private string brandField;

        private System.DateTime dateOfmanufactureField;

        private ProductSearchResultProductSummaryStatus statusField;

        private ProductSearchResultProductSummaryType typeField;

        private ProductSearchResultProductSummaryShelfLife shelfLifeField;

        /// <remarks/>
        public uint BaseProductId
        {
            get
            {
                return this.baseProductIdField;
            }
            set
            {
                this.baseProductIdField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Brand
        {
            get
            {
                return this.brandField;
            }
            set
            {
                this.brandField = value;
            }
        }

        //public System.DateTime DateOfmanufacture
        //{
        //    get
        //    {
        //        return this.dateOfmanufactureField;
        //    }
        //    set
        //    {
        //        this.dateOfmanufactureField = value;
        //    }
        //}

        /// <remarks/>
        public ProductSearchResultProductSummaryStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public ProductSearchResultProductSummaryType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public ProductSearchResultProductSummaryShelfLife ShelfLife
        {
            get
            {
                return this.shelfLifeField;
            }
            set
            {
                this.shelfLifeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummaryStatus
    {

        private ProductSearchResultProductSummaryStatusProductSummaryStatus productSummaryStatusField;

        /// <remarks/>
        public ProductSearchResultProductSummaryStatusProductSummaryStatus ProductSummaryStatus
        {
            get
            {
                return this.productSummaryStatusField;
            }
            set
            {
                this.productSummaryStatusField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummaryStatusProductSummaryStatus
    {

        private string idField;

        private string valueField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummaryType
    {

        private ProductSearchResultProductSummaryTypeProductSummaryType productSummaryTypeField;

        /// <remarks/>
        public ProductSearchResultProductSummaryTypeProductSummaryType ProductSummaryType
        {
            get
            {
                return this.productSummaryTypeField;
            }
            set
            {
                this.productSummaryTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummaryTypeProductSummaryType
    {

        private string idField;

        private string valueField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummaryShelfLife
    {

        private ProductSearchResultProductSummaryShelfLifeProductSummaryShelfLife productSummaryShelfLifeField;

        /// <remarks/>
        public ProductSearchResultProductSummaryShelfLifeProductSummaryShelfLife ProductSummaryShelfLife
        {
            get
            {
                return this.productSummaryShelfLifeField;
            }
            set
            {
                this.productSummaryShelfLifeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductSummaryShelfLifeProductSummaryShelfLife
    {

        private object isLimitedField;

        private string expiryField;

        /// <remarks/>
        public object IsLimited
        {
            get
            {
                return this.isLimitedField;
            }
            set
            {
                this.isLimitedField = value;
            }
        }

        /// <remarks/>
        public string Expiry
        {
            get
            {
                return this.expiryField;
            }
            set
            {
                this.expiryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductProductMediaContent
    {

        private string typeField;

        private string urlField;

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductSearchResultProductProductAttribute
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}