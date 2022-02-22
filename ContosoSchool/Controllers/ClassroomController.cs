using ContosoSchool.Application.Classrooms.Commands;
using ContosoSchool.Application.Classrooms.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContosoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassroomController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(ApiRoutes.Classroom.GetById)]
        public async Task<IActionResult> GetClassroomById(int Id)
        {
            var response = await _mediator.Send(new GetClassroomById.Query(Id));
            return response == null ? NotFound() : Ok(response);
        }


        [HttpPost(ApiRoutes.Classroom.AddClassroom)]
        public async Task<IActionResult> AddClassroom(AddClassroom.Command command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet(ApiRoutes.Classroom.GetAll)]
        public async Task<IActionResult> GetAllClassroom()
        {
            var res = await _mediator.Send(new GetAllClassroom.Query());
            return res == null ? NotFound() : Ok(res);
        }
    }
}
