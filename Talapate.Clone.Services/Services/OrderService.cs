using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Order.Aggregrate;
using Talabate.Clone.Core.Services.Contruct;

namespace Talapate.Clone.Services.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int delivaryMethod, Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
