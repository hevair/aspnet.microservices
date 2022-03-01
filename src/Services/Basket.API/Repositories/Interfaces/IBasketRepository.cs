using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        public Task<ShoppingCart> GetBasket(string UserName);
        public Task<ShoppingCart> UpdateBasket(ShoppingCart Basket);
        public Task DeleteBasket(string UserName);
    }
}
