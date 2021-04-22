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

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        //It is needed otherwise we get error. It's resolving the problem with primary key creating via IdentityUser. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
