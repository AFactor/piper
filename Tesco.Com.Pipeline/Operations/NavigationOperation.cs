using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Operations.Contract;
using Tesco.Com.Pipeline.Operations.Mappers;

namespace Tesco.Com.Pipeline.Operations.Navigation
{
    public class NavigationAPIOperation : ApiOperation<Entity.Navigation>
    {
        public NavigationAPIOperation(){}

        public override IEnumerable<Entity.Navigation> Execute(IEnumerable<Entity.Navigation> input)
        {
            Entity.Hierarchy hierarchy = (Entity.Hierarchy)FromApi("NavigationAnonymous", string.Empty, ParamArray);
            input = NavigationMapper.MapNavigationCMSResponse(input);
            return input;
        }
    }

    public class NavigationCMSOperation : ApiOperation<Entity.Navigation>
    {
        public NavigationCMSOperation() { }

        public override IEnumerable<Entity.Navigation> Execute(IEnumerable<Entity.Navigation> input)
        {
            input = NavigationMapper.MapNavigationCMSResponse(input);
            return input;
        }
    }
}