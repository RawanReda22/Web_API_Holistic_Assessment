using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.DTOs.ShoppingCartDTO
{
    public class ShoppingCartOnly
    {
        [Required]
        public int NumberOfItems { get; set; }
        public int CustomerId { get; set; }

    }
}
