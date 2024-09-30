using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabate.Clone.Core.Entites
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        //Navigation Property
        public int  BrandId { get; set; }
        public ProductBrand Brand { get; set; }
        public int CategoryId { get; set; }
        public   ProductCategories Category { get; set; }
    }
}
