using ContosoSchool.Application.Validation;
using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Characters.Commands
{
    public static class AddWeapon
    {
        public record Command(WeaponDto weaponDto) : IRequest<Response>;

        public class Validator : IValidationHandler<Command>
        {
            private readonly ApplicationDbContext _context;
            public Validator(ApplicationDbContext context) => _context = context;
            
            public async Task<ValidationResult> Validate(Command request)
            {
                var character = await _context.Characters.FindAsync(request.weaponDto.CharacterId);
                if (character == null)
                    return ValidationResult.Fail($"Character Not found against Character_Id : {request.weaponDto.CharacterId}");

                return ValidationResult.Success;
            }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var character = await _context.Characters.FindAsync(request.weaponDto.CharacterId);

                var newWeapon = new Weapon
                {
                    Name = request.weaponDto.Name,
                    Damage = request.weaponDto.Damage,
                    Character = character
                };
                _context.Weapons.Add(newWeapon);
                await _context.SaveChangesAsync();

                return new Response(character);

            }
        }
        public record Response(Character character);
    }
}
