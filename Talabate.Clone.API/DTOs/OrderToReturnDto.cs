using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.API.DTOs
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderBata { get; set; } 
        public string Status { get; set; }
        public Address ShippingAddress { get; set; } 
        public string Delivarymethod { get; set; } 
        public decimal DelivarymethodCost { get; set; } 

        public ICollection<OrderItemDto> Items { get; set; } = new HashSet<OrderItemDto>();
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string? PaymentEntentId { get; set; }
    }
}
