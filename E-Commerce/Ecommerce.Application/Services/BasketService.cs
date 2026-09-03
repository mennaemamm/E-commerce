using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.DTOs.BasketsDtos;
using Ecommerce.Domain.Contracts;
using Ecommerce.Domain.Entities.Baskets;

namespace Ecommerce.Application.Services
{
    public class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
    {
        public async Task<Result<BasketDto>> CreateOrUpdateBasketAsync(BasketDto basket, CancellationToken cancellationToken = default)
        {
            var customerBasket = mapper.Map<CustomerBasket>(basket);
            var basketResult = await basketRepository.CreateOrUpdateBasketAsync(customerBasket, cancellationToken: cancellationToken);
            return basketResult != null ? Result<BasketDto>.Ok(mapper.Map<BasketDto>(basketResult)) : Result<BasketDto>.Fail(Error.Failure("BasketDelete.Failure", "Can Not Delete Basket"));

        }

        public async Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await basketRepository.DeleteBasketAsync(id, cancellationToken);
            return result ? Result<bool>.Ok(true) : Result<bool>.Fail(Error.Failure("BasketDelete.Failure", "Can Not Delete Basket"));
        }
        public async Task<Result<BasketDto>> GetBasketAsync(string id, CancellationToken cancellationToken = default)
        {
            var basket = await basketRepository.GetBasketAsync(id, cancellationToken);
            if (basket == null)
                return Result<BasketDto>.Fail(Error.NotFound("Basket Not Found"));
            return Result<BasketDto>.Ok(mapper.Map<BasketDto>(basket));
        }
    }

}
