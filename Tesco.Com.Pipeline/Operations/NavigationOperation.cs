using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Operations.Contract;
using Tesco.Com.Pipeline.Operations.Mappers;

namespace Tesco.Com.Pipeline.Operations
{
    public class NavigationOperation : ApiOperation<Navigation>
    {
        //private IApiOperation _apiOperation;
        public NavigationOperation()
        {
            
        }

        public override IEnumerable<Navigation> Execute(IEnumerable<Navigation> input)
        {
            Hierarchy hierarchy = (Hierarchy)FromApi("NavigationAnonymous", string.Empty, ParamArray);
            input = NavigationMapper.MapAPIResponse(hierarchy);
            return input;
        }
    }
}