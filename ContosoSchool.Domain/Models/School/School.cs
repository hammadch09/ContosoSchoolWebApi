namespace ContosoSchool.Domain.Models
{
    public class School : BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? NameOfPrincipal { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
