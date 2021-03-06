using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Przechowuje wartość id postaci. Następcie na frontendzie jest pobierana dana postać z api.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Id bohatera w bazie danych
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id bohatera w api
        /// </summary>
        public int CharacterId { get; set; }
        /// <summary>
        /// JsonIgnore potrzebny aby przy dodwaniu nie wchodzić w pętle.
        /// </summary>
        [JsonIgnore]
        public List<AppUserCharacter> AppUsers { get; set; } = new();

    }
}
