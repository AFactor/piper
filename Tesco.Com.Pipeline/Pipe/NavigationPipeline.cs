using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ResponseEntities.Navigation;
using Tesco.Com.Pipeline.Operations;

namespace Tesco.Com.Pipeline.Pipe
{
    public class NavigationPipeline : BasePipeline<Navigation>
    {
        public NavigationPipeline(string type, string taxonomyId = "", string business = "Grocery", string storeId = "")
	    {
            Register(new NavigationOperation(), new string[] { type, taxonomyId, business, storeId });
	    }
    }
}