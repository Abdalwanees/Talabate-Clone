using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabate.Clone.API.Errors;
using Talabate.Clone.API.Helpers;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Repository.Data.Contexts;
using Talabate.Clone.Repository.Repositories;

namespace Talabate.Clone.API.Extensions
{
    public static class ApiApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext and configure the connection string from configuration
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

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
