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
        public ProductSpecification(string sort) : base()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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

        }
        public ProductSpecification(int Id):base(P => P.Id == Id)
        {
                Includes.Add(P => P.Brand);
                Includes.Add(P => P.Category);
        }
    }
}