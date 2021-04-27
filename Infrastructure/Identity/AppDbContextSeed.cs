using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    /// <summary>
    /// Wprowadza do bazy danych początkowego użytkownika.
    /// </summary>
    public class AppDbContextSeed
    {/// <summary>
    /// Seeduje użytkownika
    /// </summary>
    /// <param name="userManager"></param>
    /// <returns></returns>
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "greg@test.com",
                    UserName = "Greg", // DisplayName
                    PhoneNumber = "577777777",
                };
                

                await userManager.CreateAsync(user, "ComplexPa$$w0rd");
            }
        }
    }
}
