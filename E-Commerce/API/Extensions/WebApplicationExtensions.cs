using Ecommerce.Domain.Contracts;

namespace Ecommerce.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedAndMigrateDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");
            var identitySeeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Identity");

            await seeder.SeedDataAsync();
            await identitySeeder.SeedDataAsync();
            return app;
        }
    }
}
