using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.DTOs.ProductDtos;
using Ecommerce.Application.Specifications;
using Ecommerce.Domain.Contracts;
using Ecommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default)
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync(ct);
            var data = _mapper.Map<IReadOnlyList<BrandDto>>(brands);
            return Result<IReadOnlyList<BrandDto>>.Ok(data);
        }
        public async Task<Result<PaginatedResult<ProductDto>>> GetAllProductsAsync(ProductQueryParams queryParams, CancellationToken cancellationToken = default)
        {

            var repo = _unitOfWork.GetRepository<Product, int>();

            var products = await repo.GetAllAsync(new ProductWithBrandAndTypeSpecifications(queryParams), cancellationToken);
            var data = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            var countSpec = new ProductCountSpecifications(queryParams);
            var countOfAllProducts = await repo.CountAsync(countSpec);
            return Result<PaginatedResult<ProductDto>>.Ok(new PaginatedResult<ProductDto>(queryParams.pageIndex, queryParams.PageSize, countOfAllProducts, data));
        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default)
        {
            var types = _mapper.Map<IReadOnlyList<TypeDto>>(await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync(ct));
            return Result<IReadOnlyList<TypeDto>>.Ok(types);
        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id, ct);
            if (product == null)
                return Result<ProductDto>.Fail(Error.NotFound("Product.NotFound", $"Product with id {id} Not Found"));
            return Result<ProductDto>.Ok(_mapper.Map<ProductDto>(product));
        }
    }
}
