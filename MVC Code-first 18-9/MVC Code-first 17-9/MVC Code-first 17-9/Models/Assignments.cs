using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Code_first_17_9.Models
{
    public class Assignments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public int StudentId { get; set; }

        public int CouseId { get; set; }



        public virtual Students Student { get; set; }

        public virtual Courses Course { get; set; }
    }
}