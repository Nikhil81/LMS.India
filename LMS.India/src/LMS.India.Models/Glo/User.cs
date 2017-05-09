using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LMS.India.Models.Glo
{
    public class User
    {
        public string Login { get; set; }

        public string DisplayName { get; set; }        

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string TinyAvatar { get; set; }

        public string SmallAvatar { get; set; }

        public int LocationId { get; set; }

        public string Ecode { get; set; }

        public string Designation { get; set; }

        public RoleType RoleType { get; set; }

       // public List<TechnologyStack> TechnologyStack { get; set; } 
    }

    public class GLOUser
    {
        public string displayname { get; set; }

        public string login { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string small_avatar { get; set; }

        public string tiny_avatar { get; set; }

        public string location { get; set; }
        
        public string ecode { get; set; }

        public string designation { get; set; }

        public RoleType RoleType { get; set; }
    }

    public class GLOAppToken
    {
        public string App_Key { get; set; }
        public string App_Token { get; set; }
    }

    public enum RoleType
    {
        Admin=1,
        Expert=2,
        User=3
    }
}
