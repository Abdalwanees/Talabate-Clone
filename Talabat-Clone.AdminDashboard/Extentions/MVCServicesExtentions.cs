using Microsoft.EntityFrameworkCore;
using Talabate.Clone.Repository.Data.Contexts;

namespace Talabat_Clone.AdminDashboard.Extentions
{
    public class MVCServicesExtentions
    {
        public IServiceCollection AddApplicationsServices(IServiceCollection services,IConfiguration configuration) 
        {
            //Allow Dependacy Injection and ask ClR to open connection with database
            services.AddDbContext<StoreDbContext>(
                options =>options.UseSqlServer(configuration.GetConnectionString("DefaultConnction"),
                B=>B.MigrationsAssembly(typeof(StoreDbContext).Assembly.FullName))  
            );
        return services;
        }
    }
}
