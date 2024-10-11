using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Talabate.Clone.API.Errors;
using Talabate.Clone.API.Extensions;
using Talabate.Clone.API.Helpers;
using Talabate.Clone.API.MiddleWare;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Repository.Data.Contexts;
using Talabate.Clone.Repository.Repositories;

namespace Talabate.Clone.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationServices(builder.Configuration); // Extention Method to register All Services
            //Allow dependancy injection
            //builder.Services.AddDbContext<StoreDbContext>(option =>
            //{
            //    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnction"));
            //});
            //builder.Services.AddScoped<IGenaricRepository<Product>, GenaricRepository<Product>>();
            //builder.Services.AddScoped<IGenaricRepository<ProductBrand>, GenaricRepository<ProductBrand>>();
            //builder.Services.AddScoped<IGenaricRepository<ProductCategories>, GenaricRepository<ProductCategories>>();
            //builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));

            //builder.Services.AddAutoMapper(typeof(MappingProfile));
            //builder.Services.Configure<ApiBehaviorOptions>(Options =>
            //{
            //    Options.InvalidModelStateResponseFactory = (actionContext) =>
            //    {
            //        var errors = actionContext.ModelState.Where(E => E.Value.Errors.Count() > 0).SelectMany(E => E.Value.Errors).Select(E => E.ErrorMessage).ToList();
            //        var response = new ApiValidationResponse()
            //        {
            //            Errors = errors
            //        };
            //        return new BadRequestObjectResult(response);
            //    };
            //}); // Register by default
            

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        var dbContext = services.GetRequiredService<StoreDbContext>();

            //        // Apply any pending migrations automatically
            //        await dbContext.Database.MigrateAsync();
            //        // Apply DataSeeding
            //        await StoreDbContextSeeding.SeedAsync(dbContext);


            //    }
            //    catch (Exception ex)
            //    {
            //        // Log errors or handle exceptions
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while migrating the database.");
            //    }
            //}



            //// Configure the HTTP request pipeline.
            //app.UseMiddleware<ExceptionMiddleware>();
            //app.UseStatusCodePagesWithRedirects("/Errors/{0}");


            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            await app.UseApplicationMiddlewares();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
