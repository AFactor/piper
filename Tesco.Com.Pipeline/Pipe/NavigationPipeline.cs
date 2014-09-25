using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Operations;
using Tesco.Com.Pipeline.Operations.Contract;

namespace Tesco.Com.Pipeline.Pipe
{
    public class NavigationPipeline : BasePipeline<Navigation>, IPipeline<Navigation>
    {
        IOperation<Navigation> _navigationOperation;

        public NavigationPipeline(IOperation<Navigation> navigationOperation)
        {
            _navigationOperation = navigationOperation;
        }

        public override BasePipeline<Navigation> Register( string[] args)
        {
            return base.Register(_navigationOperation, args);
        }
    }
}