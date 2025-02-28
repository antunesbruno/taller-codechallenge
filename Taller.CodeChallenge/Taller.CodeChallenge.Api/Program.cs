using Microsoft.OpenApi.Models;
using System.Xml.Linq;
using Taller.CodeChallenge.Api;
using Taller.CodeChallenge.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "taller-codechallenge-api", Description = "WebApi used for a Taller Code Challenge", Version = "v1" });
});

builder.Services.AddAutoMapper(AssemblyReflection.GetCurrentAssemblies());
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UsePathBase("/taller-codechallenge-api");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/taller-codechallenge-api/swagger/v1/swagger.json", "Taller Code Challente API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
