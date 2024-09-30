using Microsoft.EntityFrameworkCore;
using Talabate.Clone.Repository.Data.Contexts;

namespace Talabate.Clone.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Allow dependancy injection 
            builder.Services.AddDbContext<StoreDbContext>(option =>
            {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnction"));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<StoreDbContext>();

                    // Apply any pending migrations automatically
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Log errors or handle exceptions
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
