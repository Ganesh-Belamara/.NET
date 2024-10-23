using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi_Task.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }  // Primary Key

        [ForeignKey("User")]
        public int UserID { get; set; }  // Foreign Key to User table

        public decimal Total_Amount { get; set; }  // Total amount for the order

        // Optional navigation property to the User
        public User User { get; set; }
    }
}
