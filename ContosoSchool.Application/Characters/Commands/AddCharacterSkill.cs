using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Application.Characters.Commands
{
    public static class AddCharacterSkill
    {
        public record Command(AddCharacterSkillDto ACSDto) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _ctx;
            public Handler(ApplicationDbContext ctx)
            {
                _ctx = ctx;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var character = await _ctx.Characters
                    .Where(x => x.Id == request.ACSDto.CharacterId)
                    .Include(x => x.Skills)
                    .FirstOrDefaultAsync();
                if (character == null)
                    throw new FileNotFoundException("No data Found against Character");

                var skills = await _ctx.Skills.FindAsync(request.ACSDto.SkillId);
                if (skills == null)
                    throw new Exception("No data found against skills");

                character.Skills.Add(skills);
                await _ctx.SaveChangesAsync(cancellationToken: cancellationToken);
                return new Response(character);

            }
        }
        public record Response(Character character);
    }
}
