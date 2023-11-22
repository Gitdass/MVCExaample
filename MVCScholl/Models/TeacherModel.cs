using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCScholl.Models
{
    public class TeacherModel
    {
        public int teacherid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string gender { get; set; }

        public string email { get; set; }
        public string phoneno { get; set; }
    }
}