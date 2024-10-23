using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Busket;
using Talabate.Clone.Core.Repository.Contruct;

namespace Talabate.Clone.Repository.Repositories.Basket
{
    public class BasketRepository :IBasketRepository
    {
        private readonly IDatabase _database;

        //Install redis package to ask clr to take object
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var basket= await _database.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket?> UpdatetAsync(CustomerBasket basket)
        {
            //Add or Update if exisit
            var basketChanges = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (basketChanges is false)
            {
                return null;
            }else
            {
                return await GetBasketAsync(basket.Id);
            }
        }
    }
}
