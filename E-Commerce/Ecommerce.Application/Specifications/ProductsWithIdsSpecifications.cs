using Ecommerce.Domain.Entities.Products;

namespace Ecommerce.Application.Specifications
{
    internal class ProductsWithIdsSpecifications : BaseSpecifications<Product, int>
    {
        public ProductsWithIdsSpecifications(HashSet<int> productIds) : base(p => productIds.Contains(p.Id))
        {

        }
    }
}
