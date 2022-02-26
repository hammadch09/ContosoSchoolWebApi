namespace ContosoSchool.Domain.Models
{
    public class UserResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public User User { get; set; }
    }
}
