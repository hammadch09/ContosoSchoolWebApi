using ContosoSchool.Application.DTOs;
using ContosoSchool.Application.Validation;
using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Classrooms.Queries
{
    public class GetAllClassroom
    {
        public record Query() : IRequest<Response>;

        public class Validator : IValidationHandler<Query>
        {

            private readonly ApplicationDbContext _ctx;

            public Validator(ApplicationDbContext ctx) => _ctx = ctx;
            public async Task<ValidationResult> Validate(Query request)
            {
                if (!_ctx.Classroom.Any())
                    return ValidationResult.Fail("No record found");

                return ValidationResult.Success;
            }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _context.Classroom.ToList();
                return new Response { Classrooms = result };
            }
        }

        public record Response : CQRSResponse
        {
            public List<Classroom> Classrooms { get; init; }
        }
    }
}
