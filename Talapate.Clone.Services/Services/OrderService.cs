using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Entites.Order.Aggregrate;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Core.Services.Contruct;

namespace Talapate.Clone.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IGenaricRepository<Product> _productRepo;
        private readonly IGenaricRepository<DelivaryMethod> _delivaryRepo;
        private readonly IGenaricRepository<Order> _orderRepo;

        public OrderService(IBasketRepository basketRepo,IGenaricRepository<Product> productRepo,IGenaricRepository<DelivaryMethod> delivaryRepo,IGenaricRepository<Order> orderRepo)
        {
            _basketRepo = basketRepo;
            _productRepo = productRepo;
            _delivaryRepo = delivaryRepo;
            _orderRepo = orderRepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int delivaryMethodId, Address address)
        {
            // 01 Get Basket from basket repo  
            var basket =await _basketRepo.GetBasketAsync(basketId);
            // 02 Get Selected Item from product repo
            var orderItems=new List<OrderItem>();
            if (basket?.Items?.Count()>0)
            {
                foreach (var item in basket.Items)
                {
                    var product =await _productRepo.GetAsync(item.Id);
                    var productItemOrder = new ProductItemOrder(item.Id, product.Name, product.PictureUrl);
                    var orderItem = new OrderItem(productItemOrder, item.Quantity, product.Price);
                    orderItems.Add(orderItem);
                }
            }
            // 03 Clculate SubTotal
            var subTotal = orderItems.Sum(orderItem => orderItem.Price* orderItem.Qunatity);
            // 04 Get Delivary method from delivary mrthod repo
            var delivaryMetod =await _delivaryRepo.GetAsync(delivaryMethodId);

            // 05 Create order and save database
            var order=new Order(buyerEmail,address, delivaryMetod, orderItems,subTotal);
            _orderRepo.AddAsync(order);
            return order;
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
