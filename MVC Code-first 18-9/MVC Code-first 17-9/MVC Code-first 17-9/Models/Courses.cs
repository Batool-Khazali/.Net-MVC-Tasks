using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Code_first_17_9.Models
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }





        public virtual Teachers Teacher { get; set; }

        public virtual ICollection<Students> Student { get; set; }

        public virtual ICollection<Assignments> Assignment { get; set; }


    }
}