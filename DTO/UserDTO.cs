using System;

namespace ProductApi_Task.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } // Retained IsActive property
    }
}
