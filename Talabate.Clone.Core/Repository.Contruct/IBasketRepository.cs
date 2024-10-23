using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Busket;

namespace Talabate.Clone.Core.Repository.Contruct
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string basketId);
        Task<CustomerBasket?> UpdatetAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
