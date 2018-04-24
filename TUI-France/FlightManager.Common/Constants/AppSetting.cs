using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Common.Constants
{
    /// <summary>
    /// To share the keys of the web.config
    /// </summary>
    public class AppSetting
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static string AirportsJsonFilePath = ConfigurationManager.AppSettings["AirportsJsonFilePath"];
    }
}
