using AutoMapper;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Entites.Busket;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(D => D.BrandName, O => O.MapFrom(P => P.Brand.Name))
                .ForMember(D => D.CategoryName, O => O.MapFrom(P => P.Category.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<PictureUrlResolver>());
            CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
            CreateMap<ProductCategories, ProductCategoryDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Address>();
            CreateMap<Order, OrderToReturnDto>()
                     .ForMember(d => d.Delivarymethod, o => o.MapFrom(s => s.Delivarymethod.ShortName))
                     .ForMember(d => d.DelivarymethodCost, o => o.MapFrom(s => s.Delivarymethod.Cost));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.Product.ProductPictureUrl))
                .ForMember(d=> d.PictureUrl, O => O.MapFrom<OrderPicturUrlResolver>());


        }
    }
}
