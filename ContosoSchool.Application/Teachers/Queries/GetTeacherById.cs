using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Teachers.Queries
{
    public static class GetTeacherById
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
                var entity = _context.Teacher.Any(x => x.Id == request.Id);
                if (!entity)
                    return null;

                var teacher = _context.Teacher.FirstOrDefault(x => x.Id == request.Id);
                return teacher == null ? null : new Response(teacher);

                throw new NotImplementedException();
            }
        }

        public record Response(Teacher Teachers);
    }
}
