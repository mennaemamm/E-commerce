using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities.Products
{
    public class ProductType:BaseEntity<int>
    {
        public string Name { get; set; } = default!;

    }
}