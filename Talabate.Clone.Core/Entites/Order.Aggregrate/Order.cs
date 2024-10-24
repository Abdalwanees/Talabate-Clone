using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabate.Clone.Core.Entites.Order.Aggregrate
{
    public class Order:BaseEntity
    {
        public Order(string buyerEmail, OrderStatus status, Address shippingAddress, DelivaryMethod delivarymethod, ICollection<OrderItem> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            Status = status;
            ShippingAddress = shippingAddress;
            Delivarymethod = delivarymethod;
            Items = items;
            SubTotal = subTotal;
        }
        public Order()
        {
            
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderBata { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; }
        public Address ShippingAddress { get; set; } // 1--1 totla
        //public int? DelivarymethodId { get; set; } //FK 
        public DelivaryMethod? Delivarymethod { get; set; } // 1"Order ,mandatory" -- 1 "Delivarymethod ,Optional"
        public ICollection<OrderItem> Items { get; set; }=new HashSet<OrderItem>();
        public decimal SubTotal { get; set; }
        //public decimal Total { get; }
        public decimal GetTotal()
        => SubTotal + Delivarymethod.Cost;
        public string PaymentEntentId { get; set; }


    }
}
