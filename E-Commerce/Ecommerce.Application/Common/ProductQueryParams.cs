namespace Ecommerce.Application.Common
{
    public class ProductQueryParams
    {
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string? SearchValue { get; set; }
        public ProductSortingOptions Sort { get; set; }


        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        public int pageIndex { get; set; } = 1;

        private int _pageSize = DefaultPageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : (value < 1 ? DefaultPageSize : value);
        }
    }
}
