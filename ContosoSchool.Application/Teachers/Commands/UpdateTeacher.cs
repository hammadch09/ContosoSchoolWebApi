using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Teachers.Commands
{
    public static class UpdateTeacher
    {
        public record Command(Teacher teacher) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _ctx;
            public Handler(ApplicationDbContext ctx)
            {
                _ctx = ctx;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var teacher = _ctx.Teacher.Update(request.teacher);
                await _ctx.SaveChangesAsync(cancellationToken: cancellationToken);
                return new Response(teacher.Entity);
            }
        }
        public record Response(Teacher teacher);
    }
}
