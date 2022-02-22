using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ContosoSchool.Registrars
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseExceptionHandler(app =>
            {
                app.Run(async context =>
                {
                    // Handle exception here
                    await context.Response.WriteAsJsonAsync(new { Error = "Sorry something went wrong"});
                });
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.ApiVersion.ToString());
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
