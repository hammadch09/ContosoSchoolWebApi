using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContosoSchool.Domain.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;

        [JsonIgnore]
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
