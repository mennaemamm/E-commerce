using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Contracts
{
    public interface IDataSeeder
    {
        Task SeedDataAsync(CancellationToken ct = default);
    }
}
