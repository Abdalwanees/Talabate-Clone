using AutoMapper;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.API.Helpers
{
    public class OrderPicturUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;
        private const string ApiBaseUrlKey = "ApiBaseUrl";

        public OrderPicturUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
        
            if(!string.IsNullOrEmpty(source.Product.ProductPictureUrl))
            {
                return !string.IsNullOrEmpty(source.Product.ProductPictureUrl)
                ? $"{_configuration[ApiBaseUrlKey]}/{source.Product.ProductPictureUrl}"
                : string.Empty;

            }
            return string.Empty;
        }
    }
}
