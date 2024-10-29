using System.ComponentModel.DataAnnotations;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.API.DTOs
{
    public class OrderDto
    {
        [Required]
        public string BuyerEmail { get; set; }
        [Required]
        public string BusketId { get; set; }
        [Required]
        public int DelivaryMethod { get; set; }
        public AddressDto ShippingAddress { get; set; }
    }
}
