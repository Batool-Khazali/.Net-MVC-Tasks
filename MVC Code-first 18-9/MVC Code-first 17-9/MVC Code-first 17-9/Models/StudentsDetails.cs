using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Code_first_17_9.Models
{
    public class StudentsDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //[ForeignKey("Student")]
        public int StudentID { get; set; }

        public int phone { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public string ParentName { get; set; }




        public virtual Students Student { get; set; }
    }
}