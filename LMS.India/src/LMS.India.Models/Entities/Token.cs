using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.India.Models.Entities
{
    public class Token
    {
        [Key]
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public String AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
