using ContosoSchool.Data.Repository;
using ContosoSchool.Domain.Models;

namespace ContosoSchool.Application.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public void CreateTeacher(Teacher teacher)
        {
            _repository.Create(teacher);
        }

        public void DeleteTeacher(int id)
        {
            var teacher = GetTeacher(id);
            _repository.Remove(teacher);
            _repository.SaveChanges();
        }

        public IEnumerable<Teacher> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Teacher GetTeacher(int id)
        {
            return _repository.Get(id);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _repository.Update(teacher);
        }
    }
}
