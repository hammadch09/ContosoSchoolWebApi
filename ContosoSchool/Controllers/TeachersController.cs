#nullable disable
using ContosoSchool.Application.Services.TeacherService;
using ContosoSchool.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITeacherService _teacherService;

        public TeachersController(ApplicationDbContext context, ITeacherService teacherService)
        {
            _context = context;
            _teacherService = teacherService;
        }

        // GET: api/Teachers
        [HttpGet("paginate/id")]
        public async Task<ActionResult<List<Teacher>>> Get(int page)
        {
            if (page == 0)
            {
                return BadRequest("PageIdex is required");
            }

            if (_context.Teacher == null)
            {
                return NotFound();
            }

            var pagesResult = 3f;
            var pagesCount = Math.Ceiling(_context.Teacher.Count() / pagesResult);

            var teschers = await _context.Teacher
                .Skip((page -1) * (int)pagesResult)
                .Take((int)pagesResult)
                .ToListAsync();

            var response = new TeacherResponseDto
            {
                Teachers = teschers,
                Pages = (int)pagesCount,
                CurrentPage = page
            };

            return Ok(response);
        }

        // GET: api/Teachers/5
        [HttpGet(nameof(GetTeacher))]
        public IActionResult GetTeacher(int id)
        {
            var teacher = _teacherService.GetTeacher(id);
            return Ok(teacher);
        }

        // PUT: api/Teachers/5
        [HttpPut("update/id")]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            _teacherService.UpdateTeacher(teacher);
            return Ok("Updated!");
        }

        // POST: api/Teachers
        [HttpPost("create")]
        public IActionResult PostTeacher(Teacher teacher)
        {
            _teacherService.CreateTeacher(teacher);
            return Ok("Created!");
        }

        // DELETE: api/Teachers/5
        [HttpDelete("delete/id")]
        public IActionResult DeleteTeacher(int id)
        {
            _teacherService.DeleteTeacher(id);
            return Ok("Deleted");
        }
    }
}
