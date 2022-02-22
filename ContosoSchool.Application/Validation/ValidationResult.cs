using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Application.Validation
{
    public record ValidationResult
    {
        public bool IsSuccessful { get; set; } = true;
        public string Error { get; init; } = string.Empty;

        public static ValidationResult Success => new ValidationResult();
        public static ValidationResult Fail(string error) => new ValidationResult { IsSuccessful = false, Error = error };
    }
}
