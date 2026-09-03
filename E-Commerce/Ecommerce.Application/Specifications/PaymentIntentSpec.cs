using Ecommerce.Domain.Entities.Orders;

namespace Ecommerce.Application.Specifications
{
    internal class PaymentIntentSpec : BaseSpecifications<Order, Guid>
    {
        public PaymentIntentSpec(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}