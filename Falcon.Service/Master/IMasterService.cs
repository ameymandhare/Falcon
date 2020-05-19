using Falcon.Entity.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Service.MasterRepository
{
    public interface IMasterService
    {
        ClassConfiguration GetClassConfiguration();
        bool UpdateClassConfig(string[] AllKeys);
    }
}
