using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Teachers.Queries
{
    public static class GetTeachersWithPagination
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
                var pagesResult = 3f;
                var pagesCount = Math.Ceiling(_context.Teacher.Count() / pagesResult);

                var teachers = _context.Teacher
                    .Skip((request.Id - 1) * (int)pagesResult)
                    .Take((int)pagesResult)
                    .ToList();

                return teachers == null ? null : new Response(teachers, (int)pagesCount, request.Id);
            }
        }

        public record Response(List<Teacher> Teachers, int Pages, int CurrentPage);
    }
}
