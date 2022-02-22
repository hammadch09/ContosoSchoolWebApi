using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Application.Characters.Queries
{
    public static class GetCharacterById
    {
        public record Query(int OperatorId) : IRequest<Response>;

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var characters = await _context.Characters
                    .Where(x => x.OperatorId == request.OperatorId)
                    .Include(x => x.Weapon)
                    .Include(x => x.Skills)
                    .ToListAsync();

                return characters == null ? null : new Response(characters);
            }
        }
        public record Response(List<Character> character);
    }
}
