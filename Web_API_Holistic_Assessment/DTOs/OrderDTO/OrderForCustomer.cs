using System.ComponentModel.DataAnnotations;
using Web_API_Holistic_Assessment.DTOs.ShoppingCartDTO;

namespace Web_API_Holistic_Assessment.DTOs.OrderDTO
{
    public class OrderForCustomer
    {
        [Required]
        public string? Name { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public ShoppingCartOnly? ShoppingCart { get; set; }

    }
}
