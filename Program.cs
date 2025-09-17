using System;
using Infrastructure;
using Web.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Web.Application.Interfaces;
using Web.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICourseRepository, CourseEfRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorEfRepository>();
builder.Services.AddScoped<IStudentRepository, StudentEfRepository>();
builder.Services.AddScoped<ILessonRepository, LessonEfRepository>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
