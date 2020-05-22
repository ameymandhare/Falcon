using System;
using System.Data;
using System.Linq;
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
            DalParameterList dalParam = new DalParameterList();

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@IsSuccess",
                ParameterValue = DBNull.Value,
                ParameterDirection = ParameterDirection.Output,
                ParameterType = SqlDbType.Bit
            });

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@ClassX",
                ParameterValue = classesXRef,
                ParameterType = SqlDbType.Structured
            });

            dataAccess.ExecuteNonQuery(StoredProcedureConstants.UpdateClassConfiguration, CommandType.StoredProcedure, dalParam);
            var isSuccess = Convert.ToBoolean(dalParam.Where(x => x.ParameterName == "@IsSuccess").First().ParameterValue);

            return isSuccess;
        }
    }
}
