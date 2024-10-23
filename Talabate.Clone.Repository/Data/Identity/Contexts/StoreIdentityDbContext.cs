using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Identity;

namespace Talabate.Clone.Repository.Data.Identity.Contexts
{
    public class StoreIdentityDbContext : IdentityDbContext<AppUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("users", "Security");

            builder.Entity<Address>().ToTable("Addresses", "Security");

            builder.Entity<IdentityRole>().ToTable("roles", "Security");

            builder.Entity<IdentityUserRole<string>>().ToTable("user_roles", "Security");

            builder.Entity<IdentityUserClaim<string>>().ToTable("user_claims", "Security");

            builder.Entity<IdentityUserLogin<string>>().ToTable("user_logins", "Security");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("role_claims", "Security");

            builder.Entity<IdentityUserToken<string>>().ToTable("user_tokens", "Security");
        }
    }
}
