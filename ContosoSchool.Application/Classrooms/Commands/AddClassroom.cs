using ContosoSchool.Application.DTOs;
using ContosoSchool.Application.Validation;
using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;
using System.Net;

namespace ContosoSchool.Application.Classrooms.Commands
{
    public static class AddClassroom
    {
        // Command
        public record Command(string Number) : IRequest<CQRSResponse>;

        // Validator
        public class Validator : IValidationHandler<Command>
        {
            private readonly ApplicationDbContext _context;

            public Validator(ApplicationDbContext context) => _context = context;

            public async Task<ValidationResult> Validate(Command request)
            {
                if (_context.Classroom.Any(x => x.Number == request.Number))
                    return ValidationResult.Fail("Classroom Already Exsist");

                return ValidationResult.Success;
            }
        }

        // Handler
        public class Handler : IRequestHandler<Command, CQRSResponse>
        {
            private readonly ApplicationDbContext _ctx;
            public Handler(ApplicationDbContext ctx) => _ctx = ctx;
           
            public async Task<CQRSResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                _ctx.Classroom
                    .Add(new Classroom { Number = request.Number });
                await _ctx.SaveChangesAsync();
                return new Response { Message = "Classroom Added Successfully" };
            }
        }

        public record Response : CQRSResponse
        {
            public string Message { get; set; }
        }
    }
}
