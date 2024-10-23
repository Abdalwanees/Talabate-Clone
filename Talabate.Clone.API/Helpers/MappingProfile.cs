using AutoMapper;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Entites.Busket;

namespace Talabate.Clone.API.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(D=>D.BrandName,O=>O.MapFrom(P=>P.Brand.Name))
                .ForMember(D => D.CategoryName, O => O.MapFrom(P => P.Category.Name))
                .ForMember(D=>D.PictureUrl,O=>O.MapFrom<PictureUrlResolver>());
            CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
            CreateMap<ProductCategories, ProductCategoryDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
