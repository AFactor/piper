using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Entities.NavigationEntities
{
    public class Hierarchy
    {
        public string Name { get; set; }

        public int Level { get; set; }

        [JsonIgnore]
        public string LevelName { get; set; }

        public Child[] Children { get; set; }

        public string Type
        {
            get { return HelperMethods.Extract(LevelName, "type", ','); }
        }

        public string TaxonomyId
        {
            get { return HelperMethods.Extract(LevelName, "taxonomyId", ','); }
        }

        public string N
        {
            get { return HelperMethods.Extract(LevelName, "N", ','); }
        }

        public string Ne
        {
            get { return HelperMethods.Extract(LevelName, "Ne", ','); }
        }

        public string Lvl
        {
            get { return HelperMethods.Extract(LevelName, "lvl", ','); }
        }
    }

    public class Child
    {
        public string Name { get; set; }

        public int Level { get; set; }

        [JsonIgnore]
        public string LevelName { get; set; }

        public Child[] Children { get; set; }

        public string Type
        {
            get { return HelperMethods.Extract(LevelName, "type", ','); }
        }

        public string TaxonomyId
        {
            get { return HelperMethods.Extract(LevelName, "taxonomyId", ','); }
        }

        public string N
        {
            get { return HelperMethods.Extract(LevelName, "N", ','); }
        }

        public string Ne
        {
            get { return HelperMethods.Extract(LevelName, "Ne", ','); }
        }

        public string Lvl
        {
            get { return HelperMethods.Extract(LevelName, "lvl", ','); }
        }
    }
}