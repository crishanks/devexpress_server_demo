using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1
{
    [Obsolete]
    public class MyLoggingService : DevExpress.XtraReports.Web.Native.ClientControls.Services.IExtendedLoggingService
    {
        public void Error(string message)
        {
            Console.WriteLine("ERROR MESSAGE", message);
        }
        public void Info(string message)
        {
            Console.Write("INFO MESSAGE", message);
        }
        public void LogException(Exception exception, string message)
        {
            Console.WriteLine("EXCEPTION", exception, "LOG EXCEPTION MESSAGE", message); 
        }
    }
}