using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class TeacherResponseDto
    {
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
