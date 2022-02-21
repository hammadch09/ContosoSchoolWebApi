#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ContosoSchool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using ContosoSchool.Application.Schools.Queries;
using ContosoSchool.Application.Schools.Commands;

namespace ContosoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SchoolsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public SchoolsController(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Schools
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<School>>> GetSchool()
        {
            var schools = await _mediator.Send(new GetAllSchools.Query());
            return Ok(schools);
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _mediator.Send(new GetSchoolById.Query(id));
            return Ok(school);
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id")]
        public async Task<IActionResult> PutSchool(School school)
        {
            var res = await _mediator.Send(new UpdateSchool.Command(school));
            return Ok(res);
        }

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            var res = await _mediator.Send(new AddSchool.Command(school));
            return Ok(res);
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _mediator.Send(new DeleteSchool.Command(id));
            return Ok(school);
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }
    }
}
