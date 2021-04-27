using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    /// <summary>
    /// Reprezentacja bazy danych
    /// przechowuje informacje o bibliotekch ulubionych postaci użytkowników.
    /// </summary>
    public class LibraryDbContext : DbContext
    {
        /// <summary>
        /// Konstruktor bazowy
        /// </summary>
        /// <param name="options"></param>
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Reprezentuje tabele łącząca z AppUserem
        /// </summary>
        public DbSet<AppUserCharacter> AppUserCharacters { get; set; }
        /// <summary>
        /// Reprezentuje tabele bohaterów
        /// </summary>
        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// Ustawia klucze obce dla AppUserCharacters, oraz zmienia tryb usuwania,
        /// aby nie usunąć postaci z bibliotek innych użytkowników.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserCharacter>().HasKey(uc => new { uc.AppUserId, uc.CharacterId });
            builder.Entity<AppUserCharacter>().HasOne(e => e.Character).WithMany(e => e.AppUsers).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
    }
}
