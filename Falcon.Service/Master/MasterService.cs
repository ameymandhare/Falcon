using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
using Falcon.DataAceess.DataRepository;
using Falcon.DataAceess.ProspectRepository;
using Falcon.Entity.Master;

namespace Falcon.Service.MasterRepository
{
    public class MasterService : IMasterService
    {
        IMasterRepository repository { get; set; }

        private IAppConfig appConfig;

        public MasterService(IMasterRepository repository, IAppConfig appConfig)
        {
            this.repository = repository;
            this.appConfig = appConfig;
        }

        public ClassConfiguration GetClassConfiguration()
        {
            var result = repository.GetClassesMasterConfiguration();

            var model = new ClassConfiguration();

            model.sessionList = new List<SessionModel>();
            model.classList = new List<ClassModel>();
            model.sectionList = new List<SectionModel>();
            model.ClassXrefList = new List<ClassXref>();

            model.sessionList.AddRange(result.Tables["SessionMaster"].AsEnumerable()
                                    .Select(row => new SessionModel()
                                    {
                                        myId = Convert.ToInt32(row.Field<decimal>("myId")),
                                        Name = row.Field<string>("SessionName")
                                    }));

            model.classList.AddRange(result.Tables["ClassMaster"].AsEnumerable()
                                    .Select(row => new ClassModel()
                                    {
                                        myId = Convert.ToInt32(row.Field<decimal>("myId")),
                                        Name = row.Field<string>("ClassName")
                                    }));

            model.sectionList.AddRange(result.Tables["SectionMaster"].AsEnumerable()
                                    .Select(row => new SectionModel()
                                    {
                                        myId = Convert.ToInt32(row.Field<decimal>("myId")),
                                        Name = row.Field<string>("SectionCode")
                                    }));

            model.ClassXrefList.AddRange(result.Tables["ClassXref"].AsEnumerable()
                                    .Select(row => new ClassXref()
                                    {
                                        myId = Convert.ToInt32(row.Field<decimal>("myId")),
                                        ClassId = Convert.ToInt32(row.Field<decimal>("refClassId")),
                                        SectionId = Convert.ToInt32(row.Field<decimal>("refSecId")),
                                        SessionId = Convert.ToInt32(row.Field<decimal>("refSessionId")),
                                        Strength = 0/*Convert.ToInt32(row.Field<decimal>("Strength"))*/
                                    }));

            return model;
        }
    }
}
