using Ecommerce.Domain.Entities.Orders;

namespace Ecommerce.Application.Specifications
{
    internal class OrderSpecifications : BaseSpecifications<Order, Guid>
    {
        public OrderSpecifications(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderSpecifications(Guid id, string email) : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
        }
    }
}
