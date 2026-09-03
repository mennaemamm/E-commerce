using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities.Products
{
    public class ProductBrand:BaseEntity<int>
    {
        public string Name { get; set; } = default!;

    }
}