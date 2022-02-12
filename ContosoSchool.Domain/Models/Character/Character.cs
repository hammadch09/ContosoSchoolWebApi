using System.Text.Json.Serialization;

namespace ContosoSchool.Domain.Models
{
    public class Character : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";

        [JsonIgnore]
        public Operator Operator { get; set; }
        public int OperatorId { get; set; }
        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
