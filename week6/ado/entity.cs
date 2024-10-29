using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado
{
    public class School
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
    }

    public class Class
    {
        public int ClassID { get; set; }
        public int SchoolID { get; set; }
        public string ClassName { get; set; }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public string StudentName { get; set; }
    }

    public class Log
    {
        public int LogID { get; set; }
        public string OperationSql { get; set; }
        public DateTime OperationTime { get; set; }
    }
    public class StudentInfo
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string SchoolName { get; set; }
    }
}
