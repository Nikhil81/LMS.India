using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.India.Models.Entities
{
    public class Sessions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sessions_Id { get; set; }
        public string SessionName { get; set; }
        public string SessionNominatedBy { get; set; }

        public bool IsInternal { get; set; }
        public DateTime Sessiondate { get; set; }
        public TimeSpan SessionTime { get; set; }

        public int Durations { get; set; }

        public ICollection<Trainees> Audiences { get; set; }

        public DateTime LastDateOfRegistration { get; set; }
        public bool IsActive { get; set; }

        public Trainer Trainer { get; set; }

        public bool IsEnroll { get; set; }



    }
}
