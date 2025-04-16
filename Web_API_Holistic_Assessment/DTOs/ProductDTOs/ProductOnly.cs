using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.DTOs.ProductDTOs
{
    public class ProductOnly
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }
}
