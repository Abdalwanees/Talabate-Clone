using System.ComponentModel.DataAnnotations;

namespace Talabate.Clone.API.DTOs
{
    public class AddressDto
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
    }
}