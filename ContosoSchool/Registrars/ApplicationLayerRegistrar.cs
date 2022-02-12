using ContosoSchool.Application.Services.AuthService;
using ContosoSchool.Application.Services.StudentService;
using ContosoSchool.Application.Services.TeacherService;
using ContosoSchool.Application.Services.UserService;
using ContosoSchool.Data.Repository;

namespace ContosoSchool.Registrars
{
    public class ApplicationLayerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();
        }
    }
}
