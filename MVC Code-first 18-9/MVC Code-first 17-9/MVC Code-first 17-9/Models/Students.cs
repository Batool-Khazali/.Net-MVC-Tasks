using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Code_first_17_9.Models
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[StringLength(50, ErrorMessage = "name can only be 50 characters")]
        public string Name { get; set; }

        public string Grade { get; set; }





        public virtual ICollection<Assignments> Assignments { get; set; }

        public virtual StudentsDetails Details { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }


    }
}