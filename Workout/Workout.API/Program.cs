using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workout.API.Extensions;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");
});

builder.Services.AddSwagger();

var app = builder.Build();

app.MapCarter();
app.MapSwagger();

app.Run();