using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabate.Clone.Core.Entites.Order.Aggregrate
{
    public class OrderItem:BaseEntity
    {
        public OrderItem(ProductItemOrder product, int qunatity, decimal price)
        {
            Product = product;
            Qunatity = qunatity;
            Price = price;
        }
        public OrderItem()
        {
            
        }

        public ProductItemOrder Product { get; set; }
        public int Qunatity { get; set; }
        public decimal Price { get; set; }

        //Navigation prop
    }
}
