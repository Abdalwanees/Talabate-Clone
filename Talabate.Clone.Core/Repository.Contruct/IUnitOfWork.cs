using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.Core.Repository.Contruct
{
    public interface IUnitOfWork :IAsyncDisposable 
    {

        //public IGenaricRepository<Product> ProductRepo { get; set; }
        //public IGenaricRepository<ProductBrand> ProductBrandRepo { get; set; }
        //public IGenaricRepository<ProductCategories> ProductCategoryRepo { get; set; }
        //public IGenaricRepository<DelivaryMethod> DelivaryMethodRepo { get; set; }
        //public IGenaricRepository<Order> OrderRepo { get; set; }
        //public IGenaricRepository<OrderItem> PrductItemsRepo { get; set; }

        IGenaricRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        
        Task<int> CompleteAsync();
    }
}
