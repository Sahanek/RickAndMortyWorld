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
        string CreateToken(AppUser user);
    }
}
