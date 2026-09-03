using Ecommerce.API.Attributes;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    public class ProductsController(IProductService productService) : ApiBaseController
    {
        [HttpGet]
        [RedisCache(100)]
        [ProducesResponseType(typeof(PaginatedResult<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProducts([FromQuery] ProductQueryParams queryParams, CancellationToken cancellationToken)
        {
            var products = await productService.GetAllProductsAsync(queryParams, cancellationToken);
            return ToActionResult(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductByIdAsync(id, cancellationToken);
            return ToActionResult(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetAllTypes(CancellationToken cancellationToken)
            => ToActionResult(await productService.GetAllTypesAsync(cancellationToken));

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetAllBrands(CancellationToken cancellationToken)
            => ToActionResult(await productService.GetAllBrandsAsync(cancellationToken));

    }
}
