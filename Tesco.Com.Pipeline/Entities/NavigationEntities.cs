﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Entities.NavigationEntities
{

    public class Navigation
    {
        [JsonProperty("shop-groceries")]
        public Hierarchy ShopGroceries { get; set; }

        [JsonProperty("my-shopping")]
        public Hierarchy MyShopping { get; set; }

        [JsonProperty("special-offers")]
        public Hierarchy SpecialOffers { get; set; }

        [JsonProperty("meals-recipes")]
        public Hierarchy MealsRecipes { get; set; }

        [JsonProperty("in-season")]
        public Hierarchy InSeason { get; set; }

        [JsonProperty("your-benefits")]
        public Hierarchy YourBenefits { get; set; }

        [JsonProperty("delivery")]
        public Hierarchy Delivery { get; set; }
    }

    public class Hierarchy
    {
        [JsonProperty("value")]
        public string Name { get; set; }

        public string Slug
        {
            get { return HelperMethods.GenerateSlug(Name); }
        }

        [JsonIgnore]
        public string LevelName { get; set; }

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

        private const string AISLE = "Aisle";
        private List<Child> _children;
        Dictionary<string, Child> dictChild;

        [JsonIgnore]
        public List<Child> Children
        {
            get
            {
                return _children;
            }
            set
            {
                // Do not ouput Aisle children (i.e. Shelves) as Navigation does not need to display it.
                if (Type != AISLE)
                {
                    _children = value;
                    dictChild = new Dictionary<string, Child>();
                    foreach (Child child in _children)
                    {
                        dictChild.Add(child.Slug, child);
                    }

                    this.Data = dictChild;
                }
            }
        }

        private Dictionary<string, Child> _data;
        [JsonProperty("children")]
        public Dictionary<string, Child> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public List<Hero> Hero { get; set; }
    }

    public class Child
    {
        [JsonProperty("value")]
        public string Name { get; set; }

        public string Slug
        {
            get { return HelperMethods.GenerateSlug(Name); }
        }

        [JsonIgnore]
        public string LevelName { get; set; }

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

        private const string AISLE = "Aisle";
        private List<Child> _children;
        [JsonIgnore]
        public List<Child> Children 
        {
            get
            {
                return _children;
            }
            set
            {
                // Do not ouput Aisle children (i.e. Shelves) as Navigation does not need to display it.
                if (Type != AISLE)
                {
                    _children = value;
                    Dictionary<string, Child> x = new Dictionary<string, Child>();
                    foreach (Child child in _children)
                    {
                        x.Add(child.Slug, child);
                    }
                    
                    this.Data = x;
                }
            }
        }

        private Dictionary<string, Child> _data;
        [JsonProperty("children")]
        public Dictionary<string, Child> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;   
            }
        }


    }

    public class Hero
    {
        public string Value { get; set; }
    }
}