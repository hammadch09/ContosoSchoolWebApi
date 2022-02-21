using System.ComponentModel.DataAnnotations;

namespace ContosoSchool.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? token { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
