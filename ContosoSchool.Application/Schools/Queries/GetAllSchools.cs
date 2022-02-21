using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Schools.Queries
{
    public static class GetAllSchools
    {
        public record Query() : IRequest<Response>;

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var schools = _context.School.ToList();
                if (!schools.Any())
                    return null;

                return new Response(schools);
            }
        }
        public record Response(List<School> schools);
    }
}
