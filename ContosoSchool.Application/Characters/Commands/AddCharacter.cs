using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Characters.Commands
{
    public static class AddCharacter
    {
        public record Command(CreateCharacterDto characterDto) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var character = _context.Characters.Add(new Character
                {
                    Name = request.characterDto.Name,
                    RpgClass = request.characterDto.RpgClass,
                    OperatorId = request.characterDto.OperatorId
                });
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);
                return character == null ? null : new Response(character.Entity);
            }
        }

        public record Response(Character character);
    }
}
