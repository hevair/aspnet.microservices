using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository( IDistributedCache redisCache )
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string UserName)
        {
            await _redisCache.RemoveAsync(UserName);

        }

        public async Task<ShoppingCart> GetBasket(string UserName)
        {
            var basket = await _redisCache.GetStringAsync(UserName);
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart Basket)
        {
            await _redisCache.SetStringAsync(Basket.UserName, JsonConvert.SerializeObject(Basket));

            return await GetBasket(Basket.UserName);
        }
    }
}
