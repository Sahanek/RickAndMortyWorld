using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// interfejs reprezentujacy Service tworzący token.
    /// Przydatny w przypadku używania Dependency Injection
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Metoda tworząca token dla wybranego użytkownika
        /// </summary>
        /// <param name="user"> użytkownik w bazie danych </param>
        /// <returns>JWT Token</returns>
        string CreateToken(AppUser user);
    }
}
