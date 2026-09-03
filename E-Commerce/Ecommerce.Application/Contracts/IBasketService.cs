using Ecommerce.Application.Common;
using Ecommerce.Application.DTOs.BasketsDtos;

namespace Ecommerce.Application.Contracts
{
    public interface IBasketService
    {
        Task<Result<BasketDto>> GetBasketAsync(string id, CancellationToken cancellationToken = default);
        Task<Result<BasketDto>> CreateOrUpdateBasketAsync(BasketDto basket, CancellationToken cancellationToken = default);
        Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken cancellationToken = default);
    }
}
