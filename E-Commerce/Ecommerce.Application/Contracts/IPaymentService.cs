using Ecommerce.Application.Common;
using Ecommerce.Application.DTOs.BasketsDtos;

namespace Ecommerce.Application.Contracts
{
    public interface IPaymentService
    {
        Task<Result<BasketDto>> CreateOrUpdatePaymentIntentAsync(string basketId, CancellationToken cancellationToken = default);
        Task PaymentSucceeded(string paymentIntentId);
        Task PaymentFailed(string paymentIntentId);
    }

}
