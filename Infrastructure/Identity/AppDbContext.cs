using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    /// <summary>
    /// Reprezentuje bazę danych z informacjami o użytkowniku.
    /// Do modyfikowania danych wykorzystuje UserManager i SignInManager
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        /// <summary>
        /// Konstruktor bazowy
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        /// <summary>
        /// It is needed otherwise we get error. It's resolving the problem with primary key creating via IdentityUser. 
        /// </summary>
        /// <param name="builder"></param>
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
