using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.Core.Specifications.ProductSpecifications
{
    public class ProductWithFilterationSpecCount:BaseSpecifications<Product>
    {
        public ProductWithFilterationSpecCount(ProductSpecParams spec) : base(P =>
        (string.IsNullOrEmpty(spec.Search)||P.Name.ToLower().Contains(spec.Search.ToLower()))&&
        (!spec.BrandId.HasValue || P.BrandId == spec.BrandId.Value) &&
        (!spec.CategoryId.HasValue|| P.CategoryId==spec.CategoryId.Value)
        ){ }
    }
}
