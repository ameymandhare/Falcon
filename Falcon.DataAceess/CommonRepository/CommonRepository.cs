using Configuration;
using DataAccess;
using DataAccess.DataProvider;
using Falcon.DataAceess.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;

namespace Falcon.DataAceess
{
    public class CommonRepository : ICommonRepository
    {
        public DataSet GetMasterData()
        {
            AppConfig config = new AppConfig();

            MsSqlDataAccess dataAccess = new MsSqlDataAccess(config.FalconConnectionString);

            string[] tableNames = {
                CacheKeyConstants.BloodGrpMaster, CacheKeyConstants.AdmStatusMaster,
                CacheKeyConstants.ReligionMaster, CacheKeyConstants.CasteMaster,
                CacheKeyConstants.CategoryMaster, CacheKeyConstants.SessionMaster,
                CacheKeyConstants.ClassMaster, CacheKeyConstants.SectionMaster,
                CacheKeyConstants.GenderMaster
            };

            return dataAccess.GetDataSet(StoredProcedureConstants.GetMasterData, CommandType.StoredProcedure, tableNames);
        }
    }
}