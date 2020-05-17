using System.Data;
using Configuration;
using DataAccess;
using Enum;

namespace Falcon.DataAceess.DataRepository
{
    public class MasterRepository : IMasterRepository
    {
        IDataAccess dataAccess = null;

        public MasterRepository(IRepository repository)
        {
            dataAccess = repository.FalconDataAccess;
        }


        public DataSet GetClassesMasterConfiguration()
        {
            string[] tableNames = { "SessionMaster", "ClassMaster", "SectionMaster", "ClassXref" };

            return dataAccess.GetDataSet(StoredProcedureConstants.GetClassConfiguration, CommandType.StoredProcedure, tableNames);
        }

        public bool UpdateClassesMasterConfiguration(DataTable classesXRef)
        {
            throw new System.NotImplementedException();
        }
    }
}
