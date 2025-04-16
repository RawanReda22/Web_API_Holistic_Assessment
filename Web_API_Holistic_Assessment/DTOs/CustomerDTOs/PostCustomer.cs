using System.ComponentModel.DataAnnotations;
using Web_API_Holistic_Assessment.DTOs.OrderDTO;
using Web_API_Holistic_Assessment.DTOs.ShoppingCartDTO;
using Web_API_Holistic_Assessment.Models;

namespace Web_API_Holistic_Assessment.DTOs.CustomerDTOs
{
    public class PostCustomer
    {


        [Required]
        public string? Name { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public ShoppingCartOnly? ShoppingCart { get; set; }
        public IList<OrderForProduct>? Orders { get; set; }
    }
}
