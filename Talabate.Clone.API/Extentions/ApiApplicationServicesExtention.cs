using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabate.Clone.API.Errors;
using Talabate.Clone.API.Helpers;
using Talabate.Clone.Core.Entites.Identity;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Repository.Data.Contexts;
using Talabate.Clone.Repository.Data.Identity.Contexts;
using Talabate.Clone.Repository.Repositories;
using Talabate.Clone.Repository.Repositories.Basket;

namespace Talabate.Clone.API.Extensions
{
    public static class ApiApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the StoreDbContext and configure the connection string from configuration
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            // Register the StoreIdentityDbContext and configure the connection string from configuration
            services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    //options.Password.RequireNonAlphanumeric = true;
                    //options.Password.RequireDigit = true;
                }).AddEntityFrameworkStores<StoreIdentityDbContext>();
            //Register IConnectionMultiplexer Service-->Same object for any call
            services.AddSingleton<IConnectionMultiplexer>((serviceProvider) =>
            {
                var connection = configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);


            });


            // Register Basket Repository Services
            services.AddScoped<IBasketRepository, BasketRepository>();

            // Register Generic Repository Services
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));

            // Register AutoMapper Services
            services.AddAutoMapper(typeof(MappingProfile));


            // Register validation error configuration for API responses
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState
                                              .Where(e => e.Value.Errors.Count > 0)
                                              .SelectMany(e => e.Value.Errors)
                                              .Select(e => e.ErrorMessage).ToList();

                    var response = new ApiValidationResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });
            return services;
        }
    }
}
