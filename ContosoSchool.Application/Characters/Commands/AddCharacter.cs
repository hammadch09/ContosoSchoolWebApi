using ContosoSchool.Application.DTOs;
using ContosoSchool.Application.Validation;
using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Characters.Commands
{
    public static class AddCharacter
    {
        public record Command(CreateCharacterDto characterDto) : IRequest<Response>;

        public class Validator : IValidationHandler<Command>
        {

            private readonly ApplicationDbContext _context;

            public Validator(ApplicationDbContext context) => _context = context;
            
            public async Task<ValidationResult> Validate(Command request)
            {
                var res = _context.Characters.FirstOrDefault(x => x.Name == request.characterDto.Name);
                if (res != null)
                    return ValidationResult.Fail("Character is already exsist.");

                return ValidationResult.Success;
            }
        }

        public class Handler : IRequestHandler<Command, Response>
        {

            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context) => _context = context;
           
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var character = _context.Characters.Add(new Character
                {
                    Name = request.characterDto.Name,
                    RpgClass = request.characterDto.RpgClass,
                    OperatorId = request.characterDto.OperatorId
                });
                await _context.SaveChangesAsync();
                return new Response { character = character.Entity };
            }
        }

        public record Response : CQRSResponse
        {
            public Character character { get; init; }
        }
    }
}
