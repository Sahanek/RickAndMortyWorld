using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<AppUserCharacter> AppUserCharacters { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserCharacter>().HasKey(uc => new { uc.AppUserId, uc.CharacterId });
            builder.Entity<AppUserCharacter>().HasOne(e => e.Character).WithMany(e => e.AppUsers).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
    }
}
