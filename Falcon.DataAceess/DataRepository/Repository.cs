using Configuration;
using DataAccess;
using Enum;

namespace Falcon.DataAceess.DataRepository
{
    public class Repository : IRepository
    {
        public FactoryDataAccess FalconFactoryDataAccess = null;

        public IDataAccess FalconDataAccess { get; }

        public Repository(IAppConfig config)
        {
            FalconFactoryDataAccess = new FactoryDataAccess((Provider)config.Provider, config.FalconConnectionString);
            FalconDataAccess = FalconFactoryDataAccess.GetDataAccess(); 
        }
    }
}
