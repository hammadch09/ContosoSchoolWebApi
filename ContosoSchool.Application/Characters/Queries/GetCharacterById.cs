using ContosoSchool.Application.DTOs;
using ContosoSchool.Application.Validation;
using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Application.Characters.Queries
{
    public static class GetCharacterById
    {
        public record Query(int OperatorId) : IRequest<Response>;

        public class Validator : IValidationHandler<Query>
        {

            private readonly ApplicationDbContext _context;
            public Validator(ApplicationDbContext context) => _context = context;

            public async Task<ValidationResult> Validate(Query request)
            {
                var res = _context.Characters.Where(x => x.OperatorId == request.OperatorId);
                if (!_context.Characters.Any(x => x.OperatorId == request.OperatorId))
                    return ValidationResult.Fail("Character not found.");

                return ValidationResult.Success;
            }
        }

        public class Handler : IRequestHandler<Query, Response>
        {

            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context) => _context = context;

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var characters = await _context.Characters
                    .Where(x => x.OperatorId == request.OperatorId)
                    .Include(x => x.Weapon)
                    .Include(x => x.Skills)
                    .ToListAsync();

                return new Response{ character = characters };
            }
        }
        public record Response() : CQRSResponse
        {
            public List<Character> character { get; set; }
        }
    }
}
