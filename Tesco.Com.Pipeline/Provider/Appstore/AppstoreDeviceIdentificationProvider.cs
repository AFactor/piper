using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.DeviceIdentificationSvc;
using Tesco.Com.Pipeline.Provider.Contract;

namespace Tesco.Com.Pipeline.Provider.Appstore
{
    public class AppstoreDeviceIdentificationProvider : IDeviceIdentificationProvider
    {
        //public AppstoreDeviceIdentificationProvider(IDeviceIdentificationServiceClient)
        //{

        //}
        public DeviceIdentificationSvc.DeviceFamily GetDeviceFamily(string useragent, DeviceIdentificationSvc.CallContext callcontext)
        {
            DeviceIdentificationServiceClient deviceIdentificationSvc = new DeviceIdentificationServiceClient();
            DeviceFamily deviceFamily = deviceIdentificationSvc.GetDeviceFamily(useragent, callcontext);
            return deviceFamily;
        }
    }
}