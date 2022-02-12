using ContosoSchool.Domain.Models;

namespace ContosoSchool.Application.Services.StudentService
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
