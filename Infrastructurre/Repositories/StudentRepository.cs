using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Application.DTOs;
using Web.Application.Interfaces;
using Web.Core.Models;

namespace Web.Infrastructure.Repositories
{
    public class StudentEfRepository : IStudentRepository
    {
        private readonly WebDbContext _dbContext;

        public StudentEfRepository(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            return await _dbContext.Students
                .AsNoTracking()
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    CourseIds = s.Courses.Select(c => c.Id).ToList()
                })
                .ToListAsync();
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Students
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    CourseIds = s.Courses.Select(c => c.Id).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(CreateStudentDto dto)
        {
            var student = new StudentEntity
            {
                UserName = dto.UserName
            };

            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            if (dto.CourseIds.Any())
            {
                var courses = await _dbContext.Courses
                    .Where(c => dto.CourseIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var course in courses)
                {
                    student.Courses.Add(course);
                }

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(CreateStudentDto dto)
        {
            var student = await _dbContext.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == dto.Id);

            if (student != null)
            {
                student.UserName = dto.UserName;
                student.Courses.Clear();

                var courses = await _dbContext.Courses
                    .Where(c => dto.CourseIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var course in courses)
                {
                    student.Courses.Add(course);
                }

                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            await _dbContext.Students
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }

        public Task<List<StudentDto>> GetByPageAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
