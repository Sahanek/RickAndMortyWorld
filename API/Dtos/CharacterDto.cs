using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos
{
    /// <summary>
    /// Klasa ddo przechwytywania id bohatera do dodania w bibliotece.
    /// </summary>
    public class CharacterDto
    {
        [Required]
        public int Id { get; set; }

    }
}
