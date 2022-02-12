using ContosoSchool.Domain.Models;

namespace ContosoSchool.Application.Services.TeacherService
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAllStudents();
        Teacher GetTeacher(int id);
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(int id);
    }
}
