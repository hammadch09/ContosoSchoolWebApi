using System.Text.Json.Serialization;

namespace ContosoSchool.Domain.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }

        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}
