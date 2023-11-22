using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCScholl.Models
{
    public class Classmodel
    {
        public int classid { get; set; }
        public string Section { get; set; }
        public string TeacherName { get; set; }
        public int Totalstudents { get; set; }
    }
}