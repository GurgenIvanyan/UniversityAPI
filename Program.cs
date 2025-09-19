using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Application.Interfaces;
using Web.Application.Services;
using Web.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// DbContext
// --------------------
builder.Services.AddDbContext<WebDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// --------------------
// Repositories
// --------------------
builder.Services.AddScoped<IAuthorRepository, AuthorEfRepository>();
builder.Services.AddScoped<ILessonRepository, LessonEfRepository>();
builder.Services.AddScoped<IStudentRepository, StudentEfRepository>();
builder.Services.AddScoped<ICourseRepository, CourseEfRepository>();

// --------------------
// Services
// --------------------
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<LessonService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();

// --------------------
// Controllers
// --------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --------------------
// Middleware
// --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
