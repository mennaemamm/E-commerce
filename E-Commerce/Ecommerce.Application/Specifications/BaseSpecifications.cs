using Ecommerce.Domain.Common;
using Ecommerce.Domain.Contracts;
using System.Linq.Expressions;

namespace Ecommerce.Application.Specifications
{
    internal abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        protected BaseSpecifications(Expression<Func<TEntity, bool>>? criteria = null)
        {
            Criteria = criteria;
        }

        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

        protected void AddInclude(Expression<Func<TEntity, object>> include) => IncludeExpressions.Add(include);
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }


        protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy) => OrderBy = orderBy;
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending) => OrderByDescending = orderByDescending;
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; private set; }
        protected void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
    }
}
