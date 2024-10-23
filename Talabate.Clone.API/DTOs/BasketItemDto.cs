using System.ComponentModel.DataAnnotations;

namespace Talabate.Clone.API.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Invalid Price, Must be greater than Zero")]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Quantity, Must be at least one or greater than Zero")]
        public int Quantity { get; set; }
    }
}
