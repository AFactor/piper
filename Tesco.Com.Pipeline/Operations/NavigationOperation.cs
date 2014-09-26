using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Operations.Contract;
using Tesco.Com.Pipeline.Operations.Mappers;

namespace Tesco.Com.Pipeline.Operations.Navigation
{
    public class NavigationOperation : ApiOperation<Entity.Navigation>
    {
        public NavigationOperation(){}

        public override IEnumerable<Entity.Navigation> Execute(IEnumerable<Entity.Navigation> input)
        {
            Entity.Hierarchy hierarchy = (Entity.Hierarchy)FromApi("NavigationAnonymous", string.Empty, ParamArray);
            input = NavigationMapper.MapAPIResponse(hierarchy);
            return input;
        }
    }
    
}