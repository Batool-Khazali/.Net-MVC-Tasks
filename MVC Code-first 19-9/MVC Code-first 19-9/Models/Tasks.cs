using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Code_first_19_9.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [ForeignKey("classe")]
        public int ClassID { get; set; }

        [ForeignKey("subject")]
        public int SubjectID { get; set; }





        public virtual Classes classe { get; set; }

        public virtual Subjects subject { get; set; }

    }
}