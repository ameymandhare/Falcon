using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Entity.Master
{
    public class ClassConfiguration
    {
        public List<SessionModel> sessionList;
        public List<ClassModel> classList;
        public List<SectionModel> sectionList;
        public List<ClassXref> ClassXrefList;
    }

    public class SessionModel
    {
        public int myId { get; set; }
        public string Name { get; set; }
    }

    public class ClassModel
    {
        public int myId { get; set; }
        public string Name { get; set; }
    }

    public class SectionModel
    {
        public int myId { get; set; }
        public string Name { get; set; }
    }

    public class ClassXref
    {
        public int myId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int SessionId { get; set; }
        public int Strength { get; set; }
    }
}