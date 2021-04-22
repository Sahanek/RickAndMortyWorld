using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Klasa reprezentująca Biblioteke użytkownika.
    /// Reprezentuje relacje pomiędzy userem a Postaciami w jego bibliotece.
    /// </summary>
    public class AppUserCharacter
    {
        public string AppUserId { get; set; }
        public Character Character { get; set; }
        
        public int CharacterId { get; set; }
    }
}
