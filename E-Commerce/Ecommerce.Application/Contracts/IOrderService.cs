using Ecommerce.Application.Common;
using Ecommerce.Application.DTOs.OrderDtos;

namespace Ecommerce.Application.Contracts
{
    public interface IOrderService
    {
        Task<Result<OrderToReturnDto>> CreateOrderAsync(OrderDto orderDto, string email, CancellationToken cancellationToken = default);
        Task<Result<IReadOnlyList<DeliveryMethodDto>>> GetAllDeliveryMethodsAsync(CancellationToken cancellationToken = default);
        Task<Result<IReadOnlyList<OrderToReturnDto>>> GetAllOrdersAsync(string email, CancellationToken cancellationToken = default);
        Task<Result<OrderToReturnDto>> GetOrderByIdAndEmailAsync(Guid id, string email, CancellationToken cancellationToken = default);
    }
}
