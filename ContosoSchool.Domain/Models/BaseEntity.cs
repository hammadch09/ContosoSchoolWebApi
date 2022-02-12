using System.ComponentModel.DataAnnotations;

namespace ContosoSchool.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
