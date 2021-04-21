using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppUserCharacter
    {
        public string AppUserId { get; set; }
        public Character Character { get; set; }
        
        public int CharacterId { get; set; }
    }
}
