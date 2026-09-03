using Ecommerce.Application.Common;

namespace Ecommerce.Application.Contracts
{
    public interface IPaymentGateway
    {
        Task<PaymentIntentResult> CreatePaymentIntentAsync(decimal amount, string currency, CancellationToken cancellationToken = default);
        Task<PaymentIntentResult> UpdatePaymentIntentAsync(string paymentIntentId, decimal amount, CancellationToken cancellationToken = default);
    }
}
