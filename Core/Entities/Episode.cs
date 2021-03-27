using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Episode
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        
        public DateTime Air_date { get; set; }
        [MaxLength(20)]
        public string Code { get; set; } //np. S01E01

        public List<Character> Characters { get; set; } = new();

    }
}
