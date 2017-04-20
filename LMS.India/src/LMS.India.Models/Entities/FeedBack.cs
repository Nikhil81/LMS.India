using LMS.India.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.India.Models.Entities
{
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Feedback_Id { get; set; }
        public ICollection<Questions> QuestionAndRating { get; set; }

        public string Remark { get; set; }
        public int AttendeeId { get; set; }
        public int SessionId { get; set; }
        
        public DateTime FeedbackDate { get; set; }
    }
}
