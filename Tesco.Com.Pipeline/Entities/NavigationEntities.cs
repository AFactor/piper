using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities.NavigationEntities
{
    public class Hierarchy
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string LevelName { get; set; }
        public Child[] Children { get; set; }
    }

    public class Child
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string LevelName { get; set; }
        public Child[] Children { get; set; }
    }
}