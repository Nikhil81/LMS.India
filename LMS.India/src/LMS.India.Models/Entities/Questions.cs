using LMS.India.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.India.Models.Entities
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Questions_Id { get; set; }
        public string Question { get; set; }
        public int Rating { get; set; }
        public LearningObjectiveAndFacilitator LearningObjectiveAndFacilitator { get; set; }
       

    }
}
