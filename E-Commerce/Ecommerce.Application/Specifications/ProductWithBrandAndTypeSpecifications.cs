using Ecommerce.Application.Common;
using Ecommerce.Domain.Entities.Products;

namespace Ecommerce.Application.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        // Get By Id
        public ProductWithBrandAndTypeSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

        // Get All 
        public ProductWithBrandAndTypeSpecifications(ProductQueryParams queryParams)
            : base(P => (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId.Value)
            && (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId.Value)
                && (string.IsNullOrWhiteSpace(queryParams.SearchValue)
                    || P.Name.ToLower().Contains(queryParams.SearchValue!.ToLower())))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (queryParams.Sort)
            {
                case ProductSortingOptions.NameAsc: AddOrderBy(p => p.Name); break;
                case ProductSortingOptions.NameDesc: AddOrderByDescending(p => p.Name); break;
                case ProductSortingOptions.PriceAsc: AddOrderBy(p => p.Price); break;
                case ProductSortingOptions.PriceDesc: AddOrderByDescending(p => p.Price); break;
                default: AddOrderBy(p => p.Id); break;
            }
            ApplyPagination(queryParams.PageSize, queryParams.pageIndex);

        }
    }
}
