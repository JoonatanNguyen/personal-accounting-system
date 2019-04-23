using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Accounting_System_WPFApp.Dtos
{
    class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string ChildName { get; set; }

        public string ParentName { get; set; }
    }
}
