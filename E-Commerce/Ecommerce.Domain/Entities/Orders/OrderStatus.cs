namespace Ecommerce.Domain.Entities.Orders
{
    public enum OrderStatus
    {
        Pending = 0,
        PaymentReceived = 1,
        PaymentFailed = 2
    }
}