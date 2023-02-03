using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapCarter();

app.Run();