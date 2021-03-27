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
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //It is needed otherwise we get error. It's resolving the problem with primary key creating via IdentityUser. 
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Character>().Property(e => e.Status).HasConversion<string>();
            builder.Entity<Character>().Property(e => e.Gender).HasConversion<string>();

            base.OnModelCreating(builder);
        }
    }
}
