using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Specifications;

namespace Talabate.Clone.Core.Repository.Contruct
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int Id);
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> specification);
        Task<T?> GetWithSpecAsync(ISpecification<T> specification);
    }
}
