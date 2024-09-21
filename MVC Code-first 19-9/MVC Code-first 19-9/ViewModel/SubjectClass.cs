using MVC_Code_first_19_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Code_first_19_9.ViewModel
{
    public class SubjectClass
    {
        public int ClassId { get; set; }
        public Classes Class { get; set; }

        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }
    }

}