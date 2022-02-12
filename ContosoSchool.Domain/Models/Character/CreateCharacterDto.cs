using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class CreateCharacterDto
    {
        public string Name { get; set; } = "Character";
        public string RpgClass { get; set; } = "Knight";
        public int OperatorId { get; set; }
    }
}
