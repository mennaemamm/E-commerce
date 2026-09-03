using Ecommerce.Domain.Contracts;
using Ecommerce.Domain.Entities.Baskets;
using StackExchange.Redis;
using System.Text.Json;

namespace Ecommerce.Infrastructure.Repositories
{
    internal class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? timeToLive = null, CancellationToken ct = default)
        {
            var json = JsonSerializer.Serialize(basket);
            var success = await _database.StringSetAsync(basket.Id, json, timeToLive ?? TimeSpan.FromDays(30));
            return success ? basket : null;
        }

        public async Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default)
             => await _database.KeyDeleteAsync(basketId);


        public async Task<CustomerBasket?> GetBasketAsync(string basketId, CancellationToken ct = default)
        {
            var basket = await _database.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null
                : JsonSerializer.Deserialize<CustomerBasket>((string)basket!);
        }
    }
}
