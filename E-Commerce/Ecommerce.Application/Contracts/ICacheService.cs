namespace Ecommerce.Application.Contracts
{
    public interface ICacheService
    {
        Task<string?> GetAsync(string cacheKey, CancellationToken cancellationToken = default);
        Task SetAsync(string cacheKey, object cacheValue, TimeSpan timeToLive, CancellationToken cancellationToken = default);
    }

}
