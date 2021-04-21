﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }
        [JsonIgnore]
        public List<AppUserCharacter> AppUsers { get; set; } = new();

    }
}
