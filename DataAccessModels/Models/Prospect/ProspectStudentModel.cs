using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Prospect
{
    ///List prospect students Type:Xo
    public class ProspectStudent
    {
        public int Id { get; set; }

        public string ApplicationNumber { get; set; }

        public string Name { get; set; }

        public DateTime AdmissionDate { get; set; }
    }

    ///View prospect student by Application Id Type:Xo
    public class ViewProspectStudent : AddProspectStudent
    {
        public int Id { get; set; }
    }

    /// Add prospect student Type:Xi
    public class AddProspectStudent
    {
        public string ApplicationNumber { get; set; }
        public DateTime AdmissionDate { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int ClassId { get; set; }

        public int GenderId { get; set; }
        public DateTime DoB { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        AddressDetail CurrentAddress { get; set; }
        AddressDetail PeremenantAddress { get; set; }

        public int? Religion { get; set; }
        public int? Caste { get; set; }
        public int? Category { get; set; }

        public int? BloodGrp { get; set; }
        public string AadharId { get; set; }

        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmailId { get; set; }
        public string ParentRelationship { get; set; }
        public string ParentOccupation { get; set; }

        public int AdmissionStatusId { get; set; }
        public string Notes { get; set; }

        /// Update prospect student Type:Xi
        public class UpdateProspectStudent : AddProspectStudent
        {
            public int Id { get; set; }
        }
    }
}