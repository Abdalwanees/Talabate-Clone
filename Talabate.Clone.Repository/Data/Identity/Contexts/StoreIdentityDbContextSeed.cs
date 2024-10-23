using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Identity;

namespace Talabate.Clone.Repository.Data.Identity.Contexts
{
    public class StoreIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    DisplayName = "Abdalwanees Alsayed",
                    Email="Wanees.Sayed@gmail.com",
                    UserName="Wanees.Sayed",
                    PhoneNumber="01554563693"
                };
                await _userManager.CreateAsync(user,"Pa$$w0rd");   
            }
        }
    }
}
