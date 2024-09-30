using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Repository.Data.Contexts;

namespace Talabate.Clone.Repository.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        public GenaricRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(int Id)
        {
            //if (typeof(T)==typeof(Product))
            //{
            //    return  await _dbContext.Set<Product>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
            //}
            return await _dbContext.Set<T>().FindAsync(Id);
        }
    }
}
