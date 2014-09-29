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
        IOperation<Navigation> _navigationAPIOperation, _navigationCMSOperation;

        public NavigationPipeline(IOperation<Navigation> navigationAPIOperation)//, IOperation<Navigation> navigationCMSOperation)
        {
            _navigationAPIOperation = navigationAPIOperation;
            //_navigationCMSOperation = navigationCMSOperation;
        }

        public override IPipeline<Navigation> Register(string[] args)
        {
            return base.Register(_navigationAPIOperation, args);
        }
    }
}