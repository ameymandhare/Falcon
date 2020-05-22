using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Falcon.DataAceess.DataRepository
{
    public interface IRepository
    {
        IDataAccess FalconDataAccess { get; }
    }
}
