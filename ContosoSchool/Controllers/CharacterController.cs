using ContosoSchool.Application.Characters.Commands;
using ContosoSchool.Application.Characters.Queries;
using ContosoSchool.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContosoSchool.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public CharacterController(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Character.GetCharacter)]
        public async Task<ActionResult<List<Character>>> GetCharacter(int OperatorId)
        {
            throw new Exception("This is test");
            var operators = await _context.Operators.FindAsync(OperatorId);
            if (operators == null)
                return NotFound();

            var characters = await _mediator.Send(new GetCharacterById.Query(OperatorId));
            return Ok(characters);
        }

        [HttpPost(ApiRoutes.Character.AddCharacter)]
        public async Task<ActionResult<List<Character>>> PostCharacter(CreateCharacterDto request)
        {
            var user = await _context.Operators.FindAsync(request.OperatorId);
            Console.WriteLine(user);
            if (user == null)
                return BadRequest($"Operator not found against Id {request.OperatorId}");

            var res = await _mediator.Send(new AddCharacter.Command(request));
            return res == null ? BadRequest() : Ok(res);
        }

        [HttpPost(ApiRoutes.Character.AddWeapon)]
        public async Task<ActionResult<Character>> AddWeapon(WeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
            {
                return NotFound($"Character not found against Id {request.CharacterId}");
            }

            var res = await _mediator.Send(new AddWeapon.Command(request));
            return Ok(res);
        }

        [HttpPost(ApiRoutes.Character.AddCharacterSkill)]
        public async Task<ActionResult<Character>> AddCharacterSkill(AddCharacterSkillDto request)
        {
            var res = await _mediator.Send(new AddCharacterSkill.Command(request));
            return res != null ? Ok(res) : NotFound();
        }
    }
}
