using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.Core.Specifications.ProductSpecifications
{
    public class ProductIncludesSpecification:BaseSpecifications<Product>
    {
        public ProductIncludesSpecification():base()
        {
            Includes.Add(P=>P.Brand);
            Includes.Add(P=>P.Category);
        }
        public ProductIncludesSpecification(int Id):base(P=>P.Id==Id)
        {
            Includes.Add(P=>P.Brand);
            Includes.Add(P=>P.Category);
        }
    }
}
