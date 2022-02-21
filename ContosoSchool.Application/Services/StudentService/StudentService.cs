using ContosoSchool.Data;
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
        private ApplicationDbContext _context;
        public StudentService(IRepository<Student> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
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

        public StudentResponse JsonResponse(Student student)
        {
            var Teacher = _context.Teacher
                .Where(t => t.Id == student.TeacherId)
                .FirstOrDefault();

            var response = new StudentResponse
            {
                StudentId = student.Id,
                StudentName = student.Name,
                TeacherId = Teacher.Id,
                TeacherName = Teacher.Name,
                experience = Teacher.Experience
            };
            return response;
        }
    }
}
