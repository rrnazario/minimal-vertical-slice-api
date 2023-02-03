using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workout.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

var app = builder.Build();

app.MapCarter();
app.MapSwagger();

app.Run();