using Ecommerce.Application.Profiles;
using Ecommerce.Application.Services;
using Ecommerce.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(C => { }, typeof(ApplicationServiceRegister).Assembly);

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddSingleton<ICacheService, CacheService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
