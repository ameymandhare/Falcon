using DataAccess;
using Falcon.DataAceess.DataRepository;
using Falcon.Entity.Prospect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.DataAceess.ProspectRepository
{
    public class ProspectStudentRepositiry : IProspectStudentRepository
    {
        IDataAccess dataAccess = null;

        public ProspectStudentRepositiry(IRepository repository)
        {
            dataAccess = repository.FalconDataAccess;
        }

       

        public List<ProspectStudentModel> GetAllProspectStudent()
        {
            string tableNames = "AllProspectStudents";

            string commandText = @"SELECT myId 
                                         ,ApplicationNo
                                         ,FirstName
                                         ,MiddleName
                                         ,LastName
                                         ,ApplicationDate
                                    FROM ProspectStudent";

            var result = dataAccess.GetDataTable(commandText, CommandType.Text, tableNames);

            List<ProspectStudentModel> prospectStudents = new List<ProspectStudentModel>();

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    prospectStudents.Add(new ProspectStudentModel
                    {
                        Id = Int32.Parse(row["myId"].ToString()),
                        Name = string.Concat(row["FirstName"].ToString(), row["MiddleName"].ToString(), row["LastName"].ToString()),
                        ApplicationNumber = row["ApplicationNo"].ToString(),
                        ApplicationDate = DateTime.Parse(row["ApplicationDate"].ToString())
                    });
                }
            }

            return prospectStudents;
        }

       

        public ViewProspectStudentModel ViewProspectStudent(int applicationId)
        {
            string tableName = "prospectStudentTable";

            DalParameterList dalParam = new DalParameterList();

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@Id",
                ParameterValue = applicationId,
                ParameterDirection = ParameterDirection.Input,
                ParameterType = SqlDbType.Int
            });

            var result = dataAccess.GetDataTable(StoredProcedureConstants.SP_GetProspectStudentById, CommandType.StoredProcedure, dalParam, tableName);

            ViewProspectStudentModel prospectStudent = null;

            if (result != null && result.Rows.Count > 0)
            {
                prospectStudent = new ViewProspectStudentModel
                {
                    Id = Int32.Parse(result.Rows[0]["myId"].ToString()),
                    FirstName = result.Rows[0]["FirstName"].ToString(),
                    MiddleName = result.Rows[0]["MiddleName"].ToString(),
                    LastName = result.Rows[0]["LastName"].ToString(),
                    ApplicationNumber = result.Rows[0]["ApplicationNo"].ToString(),
                    ApplicationDate = Convert.ToDateTime(result.Rows[0]["ApplicationDate"].ToString()),
                    AadharId = result.Rows[0]["AadharId"].ToString(),
                    ClassName = result.Rows[0]["Class"].ToString(),
                    Gender = result.Rows[0]["Sex"].ToString(),
                    DoB = Convert.ToDateTime(result.Rows[0]["DOB"].ToString()),
                    Phone = result.Rows[0]["Phone"].ToString(),
                    Email = result.Rows[0]["EmailId"].ToString(),
                    CurrentAddress = result.Rows[0]["CurrentAddress"].ToString(),
                    PeremenantAddress = result.Rows[0]["PermanentAddress"].ToString(),
                    Religion = result.Rows[0]["religion"].ToString(),
                    Caste = result.Rows[0]["caste"].ToString(),
                    Category = result.Rows[0]["category"].ToString(),
                    BloodGrp = result.Rows[0]["BloodGroup"].ToString(),
                    AdmissionStatus = result.Rows[0]["admissionstatus"].ToString(),
                    FullName = string.Concat(result.Rows[0]["FirstName"].ToString(), " ", result.Rows[0]["MiddleName"].ToString(), " ", result.Rows[0]["LastName"].ToString()),
                    Notes = "This is sample note",
                    ParentEmailId = "ameymandhare@gmail.com",
                    ParentName = "Demo Parent",
                    ParentOccupation = "Mera baap chor hai.",
                    ParentPhone = "9766355017",
                    ParentRelationship = "Guardian",
                };
            }

            return prospectStudent;
        }

        public bool AddProspectStudent(DataSet dataSet)
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
                ParameterName = "@NewProspect",
                ParameterValue = dataSet.Tables["Prospect"],
                ParameterType = SqlDbType.Structured
            });

            dataAccess.ExecuteNonQuery(StoredProcedureConstants.SP_AddNewProspect, CommandType.StoredProcedure, dalParam);
            var isSuccess = Convert.ToBoolean(dalParam.Where(x => x.ParameterName == "@IsSuccess").First().ParameterValue);
            return true;
        }

        public bool UpdateProspectStudent(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProspectStudent(int ProspectStudentId)
        {
            string commandText = @"DELETE FROM ProspectStudent WHERE myId = " + ProspectStudentId;

            var result = dataAccess.ExecuteNonQuery(commandText, CommandType.Text);

            return result > 0;
        }
    }
}
