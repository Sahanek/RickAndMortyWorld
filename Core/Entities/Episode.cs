using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Air_date { get; set; }
        public string Code { get; set; } //np. S01E01

        public List<Character> Characters { get; set; } = new();

    }
}
