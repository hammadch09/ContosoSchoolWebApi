using ContosoSchool.Data;
using MediatR;

namespace ContosoSchool.Application.Teachers.Commands
{
    public static class DeleteTeacher
    {
        public record Command(int Id) : IRequest<int>;

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var teacher = _context.Teacher.FirstOrDefault(x => x.Id == request.Id);
                if (teacher == null)
                    throw new FileNotFoundException("No data found");

                _context.Teacher.Remove(teacher);
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);
                    
                return request.Id;
            }
        }
    }
}
