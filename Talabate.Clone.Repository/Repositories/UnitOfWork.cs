using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Entites.Order.Aggregrate;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Repository.Data.Contexts;

namespace Talabate.Clone.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            // Initialize the GenericRepository for all prop
            ProductRepo=new GenaricRepository<Product>(_context); 
            ProductBrandRepo=new GenaricRepository<ProductBrand>(_context);
            ProductCategoryRepo = new GenaricRepository<ProductCategories>(_context);
            OrderRepo=new GenaricRepository<Order>(_context);
            DelivaryMethodRepo = new GenaricRepository<DelivaryMethod>(_context);
            PrductItemsRepo = new GenaricRepository<OrderItem>(_context);
        }
        public IGenaricRepository<Product> ProductRepo { get;set; }
        public IGenaricRepository<ProductBrand> ProductBrandRepo { get;set; }
        public IGenaricRepository<ProductCategories> ProductCategoryRepo { get;set; }
        public IGenaricRepository<DelivaryMethod> DelivaryMethodRepo { get;set; }
        public IGenaricRepository<Order> OrderRepo { get;set; }
        public IGenaricRepository<OrderItem> PrductItemsRepo { get;set; }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
