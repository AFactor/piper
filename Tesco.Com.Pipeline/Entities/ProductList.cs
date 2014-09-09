using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesco.Com.Pipeline.Entities
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ProductList
    {

        private SearchResultsResultSubSet[] resultSubSetField;

        private byte totalMatchedCountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResultSubSet")]
        public SearchResultsResultSubSet[] ResultSubSet
        {
            get
            {
                return this.resultSubSetField;
            }
            set
            {
                this.resultSubSetField = value;
            }
        }

        /// <remarks/>
        public byte TotalMatchedCount
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
    public partial class SearchResultsResultSubSet
    {

        private uint productIdField;

        private string hierarchyPathField;

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
        public string HierarchyPath
        {
            get
            {
                return this.hierarchyPathField;
            }
            set
            {
                this.hierarchyPathField = value;
            }
        }
    }

    
    

}
