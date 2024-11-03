using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Identity;

namespace Talabate.Clone.Core.Services.Contruct
{
    public interface IAuthService
    {
        Task<string> CreateUserAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
