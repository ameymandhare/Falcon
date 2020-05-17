using Falcon.Entity;
using Falcon.Entity.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Service.Common
{
    public interface ICommonService
    {
        Dictionary<string, List<DropdownData>> GetMasterData();

        List<PostalCodeMaster> GetPostalCodeBySearchKey(string searchKeyword);
    }
}