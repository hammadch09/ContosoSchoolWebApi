using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Schools.Commands
{
    public static class AddSchool
    {
        public record Command(School school) : IRequest<Response>;

        public record Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var school = _context.School.Add(request.school);
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);
                return new Response(school.Entity);
            }
        }
        public record Response(School school);
    }
}
