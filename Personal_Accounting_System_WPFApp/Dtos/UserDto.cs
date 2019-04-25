
using System;

namespace Personal_Accounting_System_WPFApp.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public DateTime DisableTime { get; set; }
    }
}
