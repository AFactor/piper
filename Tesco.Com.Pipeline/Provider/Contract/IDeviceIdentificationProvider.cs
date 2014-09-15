using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.DeviceIdentificationSvc;

namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IDeviceIdentificationProvider
    {
        DeviceFamily GetDeviceFamily(string useragent, CallContext callcontext);
    }
}