using ContosoSchool.Data;
using MediatR;

namespace ContosoSchool.Application.Classrooms.Queries
{
    public static class GetClassroomById
    {
        // Query
        public record Query(int Id) : IRequest<Response>;

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
                return classroom == null ? null : new Response(classroom.Id, classroom.Number, DateTime.Now);
            }
        }

        // Response
        public record Response(int Id, string Number, DateTime UpdatedAt);
    }
}
