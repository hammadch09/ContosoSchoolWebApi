#nullable disable
using ContosoSchool.Application.Services.StudentService;
using ContosoSchool.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentService _studentService;

        public StudentsController(ApplicationDbContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet(ApiRoutes.Student.GetAllRoute)]
        public IActionResult GetAllStudent()
        {
            var result = _studentService.GetAllStudents();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No record found");
        }

        // GET: api/Students/5
        [HttpGet(ApiRoutes.Student.IdRoute)]
        public IActionResult GetStudent(int id)
        {
            var result = _studentService.GetStudent(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No Record Found");
        }

        // PUT: api/Students/5
        [HttpPut(ApiRoutes.Student.UpdateRoute)]
        public IActionResult UpdateStudent(CreateStudentDto student, int id)
        {
            var studnt = new Student
            {
                Id = id,
                Name = student.Name,
                TeacherId = student.TeacherId,
            };
            _studentService.UpdateStudent(studnt);
            return Ok(studnt);
        }

        // POST: api/Students
        [HttpPost(ApiRoutes.Student.CreateRoute)]
        public IActionResult CreateStudent(CreateStudentDto request)
        {
            var student = new Student
            {
                Name = request.Name,
                TeacherId = request.TeacherId,
            };
            _studentService.CreateStudent(student);
            var response = _studentService.JsonResponse(student);
            return Ok(response);
        }

        // DELETE: api/Students/5
        [HttpDelete(ApiRoutes.Student.DeleteRoute)]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok("Deleted Successfully");
        }

    }
}
