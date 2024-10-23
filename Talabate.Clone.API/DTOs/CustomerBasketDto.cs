using System.ComponentModel.DataAnnotations;
using Talabate.Clone.Core.Entites.Busket;

namespace Talabate.Clone.API.DTOs
{
    public class CustomerBasketDto
    {
        [Required]
        public int Id { get; set; }
        public List<BasketItemDto> Items { get; set; }

    }
}
