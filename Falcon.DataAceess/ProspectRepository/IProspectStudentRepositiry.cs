﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Entity.Prospect;

namespace Falcon.DataAceess.ProspectRepository
{
    public interface IProspectStudentRepository
    {
        List<ProspectStudentModel> GetAllProspectStudent();

        ViewProspectStudentModel ViewProspectStudent(int Id);

        bool AddProspectStudent(DataSet dataSet);

        bool UpdateProspectStudent(DataSet dataSet);

        bool DeleteProspectStudent(int ProspectStudentId);
    }
}