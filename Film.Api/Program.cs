using Film.Application.Handlers;
using Film.Core.Repositories;
using Film.Infrastructure.Data;
using Film.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FilmDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

builder.Services.AddApiVersioning();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(CreateFilmCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IFilmRepository, FilmRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CreateAndSeedDatabase

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
