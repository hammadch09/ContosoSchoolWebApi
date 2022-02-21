using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Classrooms.Queries
{
    public class GetAllClassroom
    {
        public record Query() : IRequest<IEnumerable<Classroom>>;

        public class Handler : IRequestHandler<Query, IEnumerable<Classroom>>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Classroom>> 
                Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _context.Classroom.ToList();
                return result;
            }
        }
    }
}
