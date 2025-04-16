using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public IList<Product> Products { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
