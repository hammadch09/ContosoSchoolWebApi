#nullable disable
using ContosoSchool.Application.Services.TeacherService;
using ContosoSchool.Application.Teachers.Commands;
using ContosoSchool.Application.Teachers.Queries;
using ContosoSchool.Domain.Models;
using MediatR;
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
        private readonly IMediator _mediator;

        public TeachersController(ApplicationDbContext context, 
            ITeacherService teacherService, 
            IMediator mediator)
        {
            _context = context;
            _teacherService = teacherService;
            _mediator = mediator;
        }

        // GET: api/Teachers
        [HttpGet("paginate/id")]
        public async Task<ActionResult<List<Teacher>>> Get(int page)
        {
            if (page == 0)
                return BadRequest("PageIdex is required");

            var res = await _mediator.Send(new GetTeachersWithPagination.Query(page));
            return res == null ? NotFound() : Ok(res);
        }

        // GET: api/Teachers/5
        [HttpGet(nameof(GetTeacher))]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var res = await _mediator.Send(new GetTeacherById.Query(id));
            return res == null ? NotFound() : Ok(res);
        }

        // PUT: api/Teachers/5
        [HttpPut("update/id")]
        public async Task<IActionResult> UpdateTeacher(Teacher teacher)
        {
            var res = await _mediator.Send(new UpdateTeacher.Command(teacher));
            return res == null ? NotFound() : Ok(res);
            //_teacherService.UpdateTeacher(teacher);
            //return Ok("Updated!");
        }

        // POST: api/Teachers
        [HttpPost("create")]
        public async Task<IActionResult> AddTeacher(AddTeacherDto request)
        {
            var res = await _mediator.Send(new AddTeacher.Command(request));
            return Ok(res);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("delete/id")]
        public async Task<IActionResult> DeleteTeacher(int Id) 
        {
            var res = await _mediator.Send(new DeleteTeacher.Command(Id));
            return Ok(res);
        }
    }
}
