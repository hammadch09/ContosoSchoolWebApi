﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }
}
