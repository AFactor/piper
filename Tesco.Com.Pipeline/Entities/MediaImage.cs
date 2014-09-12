using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities
{
    public class MediaImage
    {
        public Alternativeimagesizes AlternativeImageSizes { get; set; }
    }

    public class Alternativeimagesizes
    {
        public Images Images { get; set; }
    }

    public class Images
    {
        public Imagemetadata[] ImageMetaData { get; set; }
    }

    public class Imagemetadata
    {
        public string url { get; set; }
        public string name { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

}