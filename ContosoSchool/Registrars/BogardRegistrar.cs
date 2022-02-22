using ContosoSchool.Application.Characters.Commands;
using ContosoSchool.Application.Classrooms.Commands;
using ContosoSchool.Application.Classrooms.Queries;
using ContosoSchool.Application.Schools.Commands;
using ContosoSchool.Application.Schools.Queries;
using ContosoSchool.Application.Teachers.Commands;
using ContosoSchool.Application.Teachers.Queries;
using MediatR;

namespace ContosoSchool.Registrars
{
    public class BogardRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //builder.Services.AddAutoMapper(typeof(Program), typeof(GetClassroomById));
            builder.Services.AddMediatR(typeof(GetClassroomById));
            builder.Services.AddMediatR(typeof(AddClassroom));
            builder.Services.AddMediatR(typeof(GetAllClassroom));

            builder.Services.AddMediatR(typeof(GetTeachersWithPagination));
            builder.Services.AddMediatR(typeof(GetTeacherById));
            builder.Services.AddMediatR(typeof(AddTeacher));
            builder.Services.AddMediatR(typeof(DeleteTeacher));
            builder.Services.AddMediatR(typeof(UpdateTeacher));

            builder.Services.AddMediatR(typeof(AddCharacter));
            builder.Services.AddMediatR(typeof(GetClassroomById));
            builder.Services.AddMediatR(typeof(AddCharacterSkill));
            builder.Services.AddMediatR(typeof(AddWeapon));

            builder.Services.AddMediatR(typeof(GetAllSchools));
            builder.Services.AddMediatR(typeof(GetSchoolById));
            builder.Services.AddMediatR(typeof(AddSchool));
            builder.Services.AddMediatR(typeof(UpdateSchool));
            builder.Services.AddMediatR(typeof(DeleteSchool));

        }
    }
}
