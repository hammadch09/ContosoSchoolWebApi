namespace ContosoSchool.Domain.Models
{
    public class Operator : BaseEntity
    {
        public string OperatorName { get; set; } = string.Empty;
        public List<Character> Characters { get; set; }
    }
}
