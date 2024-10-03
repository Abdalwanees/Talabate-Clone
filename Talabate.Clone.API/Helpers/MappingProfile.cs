using AutoMapper;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.Core.Entites;

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

        }
    }
}
