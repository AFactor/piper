using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = Tesco.Com.Pipeline.Entities.ResponseEntities;
namespace Tesco.Com.Pipeline.Operations.Contract
{
    public interface INavigationOperation : IOperation<Entity.Navigation>
    {

    }
}