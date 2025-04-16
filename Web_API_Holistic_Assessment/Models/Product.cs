using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
