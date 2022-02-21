using ContosoSchool.Data;
using MediatR;

namespace ContosoSchool.Application.Schools.Commands
{
    public static class DeleteSchool
    {
        public record Command(int Id) : IRequest<string>;

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var school = await _context.School.FindAsync(request.Id);
                if (school == null)
                    return null;

                _context.School.Remove(school);
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);
                return ($"School deleted successfully against Id {request.Id}");
            }
        }
    }
}
