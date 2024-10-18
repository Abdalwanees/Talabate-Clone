using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.Core.Specifications.ProductSpecifications
{
    public class ProductSpecification : BaseSpecifications<Product>
    {
        public ProductSpecification(ProductSpecParams specParams) : base(
            P=>
            (string.IsNullOrEmpty(specParams.Search)||P.Name.ToLower().Contains(specParams.Search.ToLower()))&&
            (!specParams.BrandId.HasValue||P.BrandId== specParams.BrandId.Value)&&
            (!specParams.CategoryId.HasValue||P.CategoryId==specParams.CategoryId.Value)
            
            )
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "price":
                    case "priceAsc":
                        AddOrderBy(p => p.Price); 
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    case "name":
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(p => p.Name);
                        break;
                    default:
                        AddOrderBy(P => P.Id);
                        break;
                }
            }
            //Total product =18
            //Page Size =5
            //page Index=2
            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }
        public ProductSpecification(int Id):base(P => P.Id == Id)
        {
                Includes.Add(P => P.Brand);
                Includes.Add(P => P.Category);
        }
    }
}