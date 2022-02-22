using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class CreateCharacterDto
    {
        public string Name { get; set; }
        public string RpgClass { get; set; }
        public int OperatorId { get; set; }
    }
}
