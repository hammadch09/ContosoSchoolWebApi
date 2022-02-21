using System.Text.Json.Serialization;

namespace ContosoSchool.Domain.Models
{
    public class Weapon : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;

        [JsonIgnore]
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
