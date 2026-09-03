using Ecommerce.Domain.Common;
using Ecommerce.Domain.Contracts;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace Ecommerce.Infrastructure.Data.DataSeeding
{
    internal class CatalogDataSeed(StoreDbContext dbContext/*, ILogger logger*/)  : IDataSeeder
    {
        public async Task SeedDataAsync(CancellationToken ct = default)
        {
            try 
            { 
                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations != null)
                    await dbContext.Database.MigrateAsync();

                var rootPath = Path.Combine(AppContext.BaseDirectory, "DataSeed");

                await SeedDataIfEmptyAsync<ProductBrand, int>(rootPath, "brands.json", ct);
                await SeedDataIfEmptyAsync<ProductType, int>(rootPath, "types.json", ct);
                await SeedDataIfEmptyAsync<Product, int>(rootPath, "products.json", ct);

                await SeedDataIfEmptyAsync<DeliveryMethod, int>(rootPath, "delivery.json", ct);

                var result = await dbContext.SaveChangesAsync(ct);
                if (result > 0)
                {
                    //logger.LogInformation($"Data Deeded Successfully,{result} rows affected");
                    Console.WriteLine($"Data Deeded Successfully,{result} rows affected");
                }
                else
                    //logger.LogInformation("Failed To Seed Data");
                    Console.WriteLine("Failed To Seed Data");
            }
        
            catch (Exception ex)
            {
                //logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
        private async Task SeedDataIfEmptyAsync<T, TKey>(string rootPath, string fileName, CancellationToken ct) where T : BaseEntity<TKey>
        {
            if (await dbContext.Set<T>().AnyAsync())
            {
                return;
            }

            var filePath = Path.Combine(rootPath, fileName);

            if (!File.Exists(filePath))
            {
                return;
            }

            using var fileStream = File.OpenRead(filePath);

            var items = await JsonSerializer.DeserializeAsync<List<T>>(fileStream);

            if (items?.Any() ?? false)
                dbContext.Set<T>().AddRange(items);
        }
        
    }
}
