using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;

namespace ContosoSchool.Application.Teachers.Commands
{
    public static class AddTeacher
    {
        public record Command(AddTeacherDto teacher) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
               var result = _context.Teacher.Add(new Teacher
               {
                    Name = request.teacher.Name,
                    Age = request.teacher.Age,
                    Experience = request.teacher.Experience,
                    Subject = request.teacher.Subject
               });
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);

                return new Response(result.Entity);
            }
        }
            public record Response(Teacher teacher);
    }
}
