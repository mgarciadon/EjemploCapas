using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation();

builder.Services.AddScoped<IMedicoService,MedicoService>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();

builder.Services.AddDbContext<ExampleDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("ExampleDbConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();