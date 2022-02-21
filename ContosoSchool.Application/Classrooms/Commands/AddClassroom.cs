using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Classrooms.Commands
{
    public static class AddClassroom
    {
        // Command
        public record Command(string Number) : IRequest<string>;

        // Handler
        public class Handler : IRequestHandler<Command, string>
        {
            private readonly ApplicationDbContext _ctx;
            public Handler(ApplicationDbContext ctx)
            {
                _ctx = ctx;
            }
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                _ctx.Classroom
                    .Add(new Classroom { Number = request.Number });
                await _ctx.SaveChangesAsync();
                return "Classroom Added Successfully";
            }
        }
    }
}
