using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.Models
{
    public class ShoppingCart
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int NumberOfItems { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
