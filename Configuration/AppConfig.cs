using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Enum;
using Constants;

namespace Configuration
{
    public class AppConfig : IAppConfig
    {
        public string FalconConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[Config.Falcon].ConnectionString;
            }
        }


        public Provider Provider
        {
            get
            {
                switch (ConfigurationManager.AppSettings[Config.DefaultProvider].ToLower())
                {
                    case "sql":
                        return Provider.MsSqlServer;
                    case "oracle":
                        return Provider.Oracle;
                    default:
                        return Provider.MsSqlServer;
                }
            }
        }


        public string UnixTimestampStartDate
        {
            get
            {
                return ConfigurationManager.AppSettings[Config.UnixTimestampStartDate];
            }
        }
    }
}
