using LMS.India.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.India.Models.Entities
{
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Training_Id { get; set; }
        public string CourseTitle { get; set; }
        public LearningType LearningType { get; set; }

        public int MaxNoOfAttendees { get; set; }

        public int NoOfSessions { get; set; }

        public Locations Locations { get; set; }

        public ICollection<Sessions> Sessions { get; set; }


    }
   

   
}
