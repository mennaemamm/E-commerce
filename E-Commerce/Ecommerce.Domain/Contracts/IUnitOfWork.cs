using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
