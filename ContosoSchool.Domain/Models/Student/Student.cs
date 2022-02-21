using System.Text.Json.Serialization;

namespace ContosoSchool.Domain.Models
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }

        [JsonIgnore]
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }


        // Many to Many Relation Student and Teacher
        //public List<Teacher> StudentTeachers { get; set; } = new List<Teacher>();
    }
}
