using Microsoft.EntityFrameworkCore;
using Talabate.Clone.API.MiddleWare;
using Talabate.Clone.Repository.Data.Contexts;

namespace Talabate.Clone.API.Extensions
{
    public static class ApiApplicationMiddlewaresExtension
    {
        public static async Task<WebApplication> UseApplicationMiddlewares(this WebApplication app)
        {
            // Handle database migration and seeding
            await MigrateDatabaseAsync(app);

            // Add exception handling middleware
            app.UseMiddleware<ExceptionMiddleware>();

            // Redirect to custom error pages based on status code
            app.UseStatusCodePagesWithRedirects("/Errors/{0}");

            // Enable Swagger only in development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }

        private static async Task MigrateDatabaseAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<StoreDbContext>();

                    // Apply database migrations
                    await dbContext.Database.MigrateAsync();

                    // Perform initial data seeding
                    await StoreDbContextSeeding.SeedAsync(dbContext);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
        }
    }
}
