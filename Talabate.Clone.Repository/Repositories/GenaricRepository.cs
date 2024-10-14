using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Core.Specifications;
using Talabate.Clone.Repository.Data.Contexts;
using Talabate.Clone.Repository.Specifications;

namespace Talabate.Clone.Repository.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        public GenaricRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IReadOnlyList < T >) await _dbContext.Set<Product>()
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .AsNoTracking().ToListAsync();
            }
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await _dbContext.Set<Product>()
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Id == id) as T; // Use id.Value since id is nullable
            }

            return await _dbContext.Set<T>().FindAsync(id); // Use id.Value for FindAsync
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification)
        {
            return await SpecificationEvaluator<T>.GetQuary(_dbContext.Set<T>(), specification)
                .AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetWithSpecAsync(ISpecification<T> specification)
        {
            return await SpecificationEvaluator<T>.GetQuary(_dbContext.Set<T>(), specification)
                .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
