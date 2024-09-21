using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_Code_first_19_9.ViewModel;

namespace MVC_Code_first_19_9.Models
{
    public class Classes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual ICollection<Subjects> subject { get; set; }

        public virtual ICollection<Students> student { get; set; }

        public virtual ICollection<Tasks> task { get; set; }

        //public virtual ICollection<SubjectClass> SubjectClasses { get; set; } // to view subject in classes




    }
}