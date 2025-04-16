using System.ComponentModel.DataAnnotations;
using Web_API_Holistic_Assessment.DTOs.CustomerDTOs;
using Web_API_Holistic_Assessment.DTOs.ProductDTOs;
using Web_API_Holistic_Assessment.Models;

namespace Web_API_Holistic_Assessment.DTOs.OrderDTO
{
    public class OrdersDTO
    {
     
        [Required]
        public int TotalPrice { get; set; }
        public IList<ProductOnly>? Products { get; set; }
        public int? CustomerId { get; set; }
        public CustomerOnly? Customer { get; set; }
    }
}
