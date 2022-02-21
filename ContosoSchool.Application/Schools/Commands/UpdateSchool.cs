using ContosoSchool.Data;
using ContosoSchool.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Application.Schools.Commands
{
    public static class UpdateSchool
    {
        public record Command(School school) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var school = _context.School.Update(request.school);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken: cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }

                return new Response(school.Entity);
            }
        }
        public record Response(School school);
    }
}
