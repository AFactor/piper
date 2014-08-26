﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Pipeline.Entities;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Controllers
{
    public class ProductBrowseController : ApiController
    {
        private readonly IProductBrowseProvider _productBrowseProvider;

        public ProductBrowseController() { }

        public ProductBrowseController(IProductBrowseProvider productBrowseProvider)
        {
            _productBrowseProvider = productBrowseProvider;
        }


        [System.Web.Http.HttpGet]
        public ProductList GetProductList(string query, string offset, string limit, string business = "Grocery")
        {
            try
            {
                return _productBrowseProvider.GetProductList(query, offset, limit, business);
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Navigation Get", ex);
                throw;
            }
        }
    }
}
