using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Falcon.DataAceess.DataRepository
{
    public interface IMasterRepository
    {
        DataSet GetClassesMasterConfiguration();

        bool UpdateClassesMasterConfiguration(DataTable classesXRef);
    }
}
