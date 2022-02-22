using ContosoSchool.Application.DTOs;
using ContosoSchool.Application.Validation;
using ContosoSchool.Data;
using MediatR;

namespace ContosoSchool.Application.Classrooms.Queries
{
    public static class GetClassroomById
    {
        // Query
        public record Query(int Id) : IRequest<Response>;

        // Validator 
        public class Validator : IValidationHandler<Query>
        {
            private readonly ApplicationDbContext _context;

            public Validator(ApplicationDbContext context) => _context = context;
           
            public async Task<ValidationResult> Validate(Query request)
            {
                var result = _context.Classroom.Any(x => x.Id == request.Id);
                if (!result)
                    return ValidationResult.Fail($"Record not found against id {request.Id}");

                return ValidationResult.Success;
            }
        }

        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly ApplicationDbContext _ctx;
            public Handler(ApplicationDbContext ctx)
            {
                _ctx = ctx;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var classroom = _ctx.Classroom.FirstOrDefault(x => x.Id == request.Id);
                if (classroom == null)
                    return null;

                return new Response 
                { 
                    Id = classroom.Id, 
                    Number = classroom.Number, 
                    UpdatedAt = DateTime.Now 
                };
            }
        }

        // Response
        public record Response : CQRSResponse
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
