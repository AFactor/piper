using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Pipeline.DeviceIdentificationSvc;
using Tesco.Com.Pipeline.Entities;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Controllers
{
    public class DeviceIdentificationController : ApiController
    {
        private readonly IDeviceIdentificationProvider _deviceIdentificationProvider;

        public DeviceIdentificationController() { }

        public DeviceIdentificationController(IDeviceIdentificationProvider deviceIdentificationProvider)
        {
            _deviceIdentificationProvider = deviceIdentificationProvider;
        }


        [System.Web.Http.HttpGet]
        public DeviceFamily GetDeviceFamily(string useragent, string callcontext = null)
        {
            try
            {
                DeviceFamily device = _deviceIdentificationProvider.GetDeviceFamily(useragent, new CallContext());
                return device;
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("GetDeviceFamily", ex);
                throw;
            }
        }
    }
}

