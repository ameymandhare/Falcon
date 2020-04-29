using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Entity.Prospect;
using Falcon.DataAceess.ProspectRepository;
using Configuration;
using System.Data;
using Utility;

namespace Falcon.Service.Prospect
{
    public class ProspectStudentService : IProspectStudentService
    {
        IProspectStudentRepository repository { get; set; }

        private IAppConfig appConfig;

        public ProspectStudentService(IProspectStudentRepository repository, IAppConfig appConfig)
        {
            this.repository = repository;
            this.appConfig = appConfig;
        }

        public List<ProspectStudentModel> GetProspectStudentList()
        {
            return repository.GetAllProspectStudent();
        }

        public ViewProspectStudentModel GetProspectStudentDetailsById(int prospectStudentId)
        {
            return repository.ViewProspectStudent(prospectStudentId);
        }

        public bool DeleteProspectStudent(int prospectStudentId)
        {
            return repository.DeleteProspectStudent(prospectStudentId);
        }

        public bool AddProspectStudent(AddProspectStudentModel prospectStudentModel)
        {
            //Generate Datatable which match the UserDefinedTableType "UT_ProspectStudent"

            DataTable prospectDataTable = new DataTable();
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ApplicationNo", DataType = typeof(string), Caption = "ApplicationNo", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_FirstName", DataType = typeof(string), Caption = "FirstName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_MiddleName", DataType = typeof(string), Caption = "MiddleName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_LastName", DataType = typeof(string), Caption = "LastName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Class", DataType = typeof(int), Caption = "ClassId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Sex", DataType = typeof(int), Caption = "GenderId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_DOB", DataType = typeof(DateTime), Caption = "DOB", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Phone", DataType = typeof(string), Caption = "PhoneNumber", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_EmailId", DataType = typeof(string), Caption = "EmailId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_CurrentAddress", DataType = typeof(string), Caption = "CurrentAddress", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_PermanentAddress", DataType = typeof(string), Caption = "PermanentAddress", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Religion", DataType = typeof(int), Caption = "ReligionId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Caste", DataType = typeof(int), Caption = "CasteId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Category", DataType = typeof(int), Caption = "CategoryId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_BloodGrp", DataType = typeof(int), Caption = "BloodGrpId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AadharId", DataType = typeof(string), Caption = "AadharId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentName", DataType = typeof(string), Caption = "ParentName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentPhone", DataType = typeof(string), Caption = "ParentName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentEmailId", DataType = typeof(string), Caption = "ParentEmailId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentRelationship", DataType = typeof(string), Caption = "ParentRelationship", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentOccupation", DataType = typeof(string), Caption = "ParentOccupation", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ApplicationDate", DataType = typeof(DateTime), Caption = "ApplicationDate", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AdmissionStatus", DataType = typeof(DateTime), Caption = "AdmissionStatus", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Notes", DataType = typeof(DateTime), Caption = "Notes", });

            DataRow row = prospectDataTable.NewRow();
            row["UT_ApplicationNo"] = NumberGenerator.RandomDigits(8);
            row["UT_FirstName"] = prospectStudentModel.FirstName;
            row["UT_MiddleName"] = prospectStudentModel.MiddleName;
            row["UT_LastName"] = prospectStudentModel.LastName;
            row["UT_Class"] = prospectStudentModel.ClassId;
            row["UT_Sex"] = prospectStudentModel.GenderId;
            row["UT_DOB"] = prospectStudentModel.DoB;
            row["UT_Phone"] = prospectStudentModel.Phone;
            row["UT_EmailId"] = prospectStudentModel.Email;
            row["UT_CurrentAddress"] = prospectStudentModel.CurrentAddress;
            row["UT_PermanentAddress"] = prospectStudentModel.PeremenantAddress;
            row["UT_Religion"] = prospectStudentModel.ReligionId;
            row["UT_Caste"] = prospectStudentModel.CasteId;
            row["UT_Category"] = prospectStudentModel.CategoryId;
            row["UT_BloodGrp"] = prospectStudentModel.BloodGrpId;
            row["UT_AadharId"] = prospectStudentModel.AadharId;
            row["UT_ParentName"] = prospectStudentModel.ParentName;
            row["UT_ParentPhone"] = prospectStudentModel.ParentPhone;
            row["UT_ParentEmailId"] = prospectStudentModel.ParentEmailId;
            row["UT_ParentRelationship"] = prospectStudentModel.ParentRelationship;
            row["UT_ParentOccupation"] = prospectStudentModel.ParentOccupation;
            row["UT_ApplicationDate"] = prospectStudentModel.ApplicationDate;
            row["UT_AdmissionStatus"] = prospectStudentModel.AdmissionStatus;
            row["UT_Notes"] = prospectStudentModel.Notes;

            prospectDataTable.Rows.Add(row);

            var dataSet = new DataSet();

            dataSet.Tables.Add(prospectDataTable);

            return repository.AddProspectStudent(dataSet);
        }
    }
}
