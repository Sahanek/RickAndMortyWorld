using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Character
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public Status Status { get; set; }

        [MaxLength(100)]
        public string Species { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public Gender Gender { get; set; }
        
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public List<Episode> Episodes { get; set; } = new();

        public List<AppUser> Users { get; set; } = new();
    }

    public enum Gender
    {
        Female,
        Male,
        Genderless,
        Unknown
    }
    public enum Status
    {
        Alive,
        Dead,
        Unknown
    }
}
