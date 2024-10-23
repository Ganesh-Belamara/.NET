using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi_Task.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "varchar(100)")] // Set an appropriate length for ProductName
        public string ProductName { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


    }
}
