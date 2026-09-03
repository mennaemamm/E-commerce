using Ecommerce.Application.Contracts;
using Ecommerce.Domain.Contracts;
using System.Text.Json;

namespace Ecommerce.Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }
        public Task<string?> GetAsync(string cacheKey, CancellationToken cancellationToken = default)
            => _cacheRepository.GetAsync(cacheKey, cancellationToken);

        public Task SetAsync(string cacheKey, object cacheValue, TimeSpan timeToLive, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(cacheValue, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return _cacheRepository.SetAsync(cacheKey, json, timeToLive, cancellationToken);
        }
    }

}
