using Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public interface IAppConfig
    {
        Provider Provider { get; }
        string FalconConnectionString { get; }
        string UnixTimestampStartDate { get; }
    }
}
