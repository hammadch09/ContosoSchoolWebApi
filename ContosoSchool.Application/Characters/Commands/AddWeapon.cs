using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Characters.Commands
{
    public static class AddWeapon
    {
        public record Command(WeaponDto weaponDto) : IRequest<Response>;

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
                if (character == null)
                    return null;

                var newWeapon = new Weapon
                {
                    Name = request.weaponDto.Name,
                    Damage = request.weaponDto.Damage,
                    Character = character
                };
                _context.Weapons.Add(newWeapon);
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);

                return new Response(character);

            }
        }
        public record Response(Character character);
    }
}
