using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi_Task.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        // New fields
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Automatically set on creation

        public bool IsActive { get; set; } = true; // Defaults to true on creation

        public bool IsDeleted { get; set; } = false; // For soft delete functionality
    }
}
