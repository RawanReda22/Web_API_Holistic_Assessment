using System.ComponentModel.DataAnnotations;

namespace Web_API_Holistic_Assessment.DTOs.CustomerDTOs
{
    public class CustomerOnly
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
