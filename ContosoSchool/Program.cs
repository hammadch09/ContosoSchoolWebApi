global using ContosoSchool.Data;
global using Microsoft.EntityFrameworkCore;
using ContosoSchool.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));

app.Run();
