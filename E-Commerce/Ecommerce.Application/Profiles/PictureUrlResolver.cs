using AutoMapper;
using Ecommerce.Application.DTOs.ProductDtos;
using Ecommerce.Domain.Entities.Products;
using Microsoft.Extensions.Options;

namespace Ecommerce.Application.Profiles
{
    public class PictureUrlResolver(IOptions<UrlSettings> options) : IValueResolver<Product, ProductDto, string?>
    {
        private readonly UrlSettings _urlSettings = options.Value;

        public string? Resolve(Product source, ProductDto destination,
                               string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
                return null;

            var baseUrl = _urlSettings.BaseUrl.TrimEnd('/');
            var path = source.PictureUrl.TrimStart('/');
            return $"{baseUrl}/Files/{path}";
        }
    }
    public class UrlSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
    }
}