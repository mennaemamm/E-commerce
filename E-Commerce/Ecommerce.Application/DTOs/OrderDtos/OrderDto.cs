using Ecommerce.Application.DTOs.Authentications;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.OrderDtos
{
    public class OrderDto
    {
        [Required]
        public string BasketId { get; set; } = default!;
        [Required]
        public int DeliveryMethodId { get; set; }
        [Required]
        public AddressDto ShipToAddress { get; set; } = default!;
    }
}
