using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_User
    {
        public int UserId { get; set; }
        public string UserName_Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserGender { get; set; }
        public string Mobile { get; set; }
        public string IsActive { get; set; }
        public DateTime UserDOB { get; set; }
        public string SkillsSet { get; set; }
        public int Experience { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
