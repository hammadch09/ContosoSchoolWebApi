#nullable disable
using ContosoSchool.Application.Services.StudentService;
using ContosoSchool.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet(nameof(GetAllStudent))]
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
        [HttpGet(nameof(GetStudent))]
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
        [HttpPut(nameof(UpdateStudent))]
        public IActionResult UpdateStudent( Student student)
        {
            _studentService.UpdateStudent(student);
            return Ok("Updated Successfully!");
        }

        // POST: api/Students
        [HttpPost(nameof(CreateStudent))]
        public IActionResult CreateStudent(Student student)
        {
            _studentService.CreateStudent(student);
            return Ok("Student Created Successfully!");
        }

        // DELETE: api/Students/5
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok("Deleted Successfully");
        }
    }
}
