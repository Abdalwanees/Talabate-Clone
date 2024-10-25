using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.Core.Services.Contruct
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail ,string basketId,int delivaryMethodId ,Address address);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail);
    }
}
