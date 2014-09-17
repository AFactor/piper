using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Tesco.Com.Pipeline.Utilities
{
    public static class Logger
    {
        private static string _infoFormat = "{1} | INFO|{0}|{2}|{3}"; //Info|Logger| datetime | thread | message  newline
        private static string _errorFormat = "{1} | ERROR|{0}|{2}|{3}| {4}"; //Info|Logger| datetime | thread | message  newline


        private static ILog _thisLog;




        private static ILog log
        {
            get
            {

                if (null == _thisLog)
                {
                    _thisLog = LogManager.GetLogger("pipeline");
                    log4net.Config.XmlConfigurator.Configure();
                }
                return _thisLog;
            }
        }

        public static void Error(object message, Exception exception)
        {
            log.ErrorFormat(_errorFormat, log.Logger.Name, DateTime.Now, System.Threading.Thread.CurrentThread.ManagedThreadId, message, exception);
        }

        public static void ErrorFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public static void ErrorFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public static void Info(object message)
        {
            log.Info(string.Format(_infoFormat, log.Logger.Name, DateTime.Now, System.Threading.Thread.CurrentThread.ManagedThreadId, message));
        }

        public static void InfoFormat(string format, params object[] args)
        {
            log.Info(string.Format( _infoFormat, log.Logger.Name, DateTime.Now, System.Threading.Thread.CurrentThread.ManagedThreadId, string.Format(format,args)));
        }
    }
}