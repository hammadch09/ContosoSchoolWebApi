using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Schools.Queries
{
    public static class GetSchoolById
    {
        public record Query(int Id) : IRequest<Response>;

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var school = _context.School.FirstOrDefault(x => x.Id == request.Id);
                if (school == null)
                    return null;

                return new Response(school);
            }
        }
        public record Response(School school);
    }
}
