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
        /// <summary>
        /// Property łączaca z bazą użytkownika
        /// </summary>
        public string AppUserId { get; set; }
        /// <summary>
        /// Property reprezentująca postać w bibliotece
        /// </summary>
        public Character Character { get; set; }
        /// <summary>
        /// Id bohatera.
        /// </summary>
        public int CharacterId { get; set; }
    }
}
