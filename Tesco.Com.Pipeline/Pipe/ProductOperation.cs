﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
namespace Tesco.Com.Pipeline.Pipe
{
    public class ProductOperation : IOperation<ProductResultETL>
    {
        public IEnumerable<string> Execute(IEnumerable<ProductResultETL> input)
        {
            
        }
    }
}