using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.DTOs.OrderDTO
{
    public class OrderOnly
    {
        [Required]
        public int TotalPrice { get; set; }
    }
}
