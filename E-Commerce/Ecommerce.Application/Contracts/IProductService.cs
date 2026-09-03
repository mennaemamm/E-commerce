using Ecommerce.Application.Common;
using Ecommerce.Application.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Contracts
{
    public interface IProductService
    {
        Task<Result<PaginatedResult<ProductDto>>> GetAllProductsAsync(ProductQueryParams queryParams, CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default);

        Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default);


    }
}
