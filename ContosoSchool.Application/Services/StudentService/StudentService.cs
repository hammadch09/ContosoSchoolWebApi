using ContosoSchool.Data.Repository;
using ContosoSchool.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Application.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private IRepository<Student> _repository;
        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public void CreateStudent(Student student)
        {
            _repository.Create(student);

        }

        public void DeleteStudent(int id)
        {
            Student student = GetStudent(id);
            _repository.Remove(student);
            _repository.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return _repository.Get(id);
        }

        public void UpdateStudent(Student student)
        {
            _repository.Update(student);
        }
    }
}
