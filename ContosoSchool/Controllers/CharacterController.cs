using ContosoSchool.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacter(int OperatorId)
        {
            var operators = await _context.Operators.FindAsync(OperatorId);
            if (operators == null)
            {
                return NotFound();
            }
            var characters = await _context.Characters
                .Where(h => h.OperatorId == OperatorId)
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .ToListAsync();

            return Ok(characters);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> PostCharacter(CreateCharacterDto request)
        {
            var user = await _context.Operators.FindAsync(request.OperatorId);
            Console.WriteLine(user);
            if (user == null)
                return BadRequest($"Operator not found against Id {request.OperatorId}");

            var newCharacter = new Character
            {
                Name = request.Name,
                RpgClass = request.RpgClass,
                OperatorId = request.OperatorId
            };

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            
            return await GetCharacter(newCharacter.OperatorId);
        }

        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> AddWeapon(WeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
            {
                return NotFound($"Character not found against Id {request.CharacterId}");
            }

            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                Character = character
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return Ok(character);
        }

        [HttpPost("skill")]
        public async Task<ActionResult<Character>> AddCharacterSkill(AddCharacterSkillDto request)
        {
            var character = await _context.Characters.Where(c => c.Id == request.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();
            if (character == null)
                return NotFound();

            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null)
                return NotFound();

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return Ok(character);
        }
    }
}
