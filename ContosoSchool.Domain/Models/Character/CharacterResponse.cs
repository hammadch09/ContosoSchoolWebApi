using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class CharacterResponse
    {
        public List<Character> Characters { get; set; } = new List<Character>();
        public int currentPage { get; set; }
        public int totalPages { get; set; }
    }
}
