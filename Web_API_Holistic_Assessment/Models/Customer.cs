using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
