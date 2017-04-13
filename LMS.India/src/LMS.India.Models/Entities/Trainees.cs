using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.India.Models.Entities
{
    public class Trainees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Trainees_Id { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Emails { get; set; }

    }
}
