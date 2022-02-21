using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class AddTeacherDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Subject { get; set; }
        public string Experience { get; set; }
    }
}
