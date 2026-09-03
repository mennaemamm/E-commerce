using Ecommerce.Domain.Entities.Baskets;

namespace Ecommerce.Domain.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string basketId, CancellationToken cancellationToken = default);
        Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? timeToLive = null, CancellationToken cancellationToken = default);
        Task<bool> DeleteBasketAsync(string basketId, CancellationToken cancellationToken = default);

    }
}
