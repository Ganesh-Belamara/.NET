using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi_Task.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
