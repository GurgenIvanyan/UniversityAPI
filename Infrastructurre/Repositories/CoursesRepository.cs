using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Application.DTOs;
using Web.Application.Interfaces;
using Web.Core.Models;

namespace Web.Infrastructure.Repositories
{
    public class CourseEfRepository : ICourseRepository
    {
        private readonly WebDbContext _dbContext;

        public CourseEfRepository(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            return await _dbContext.Courses
         .Include(c => c.Students)
         .Select(c => new CourseDto
         {
             Id = c.Id,
             Title = c.Title,
             Description = c.Description,
             Price = c.Price,
             AuthorId = c.AuthorId,
             StudentIds = c.Students.Select(s => s.Id).ToList()
         })
         .ToListAsync();
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _dbContext.Courses
        .Include(c => c.Students) 
        .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return null;

            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                AuthorId = course.AuthorId,
                StudentIds = course.Students.Select(s => s.Id).ToList()
            };
        }

        public async Task AddAsync(CreateCourseDto dto)
        {
            var course = new CourseEntity
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                AuthorId = dto.AuthorId,
                Students = await _dbContext.Students
            .Where(s => dto.StudentIds.Contains(s.Id))
            .ToListAsync()
            };

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CreateCourseDto dto)
        {
            await _dbContext.Courses
                .ExecuteUpdateAsync(c => c
                    .SetProperty(x => x.Title, dto.Title)
                    .SetProperty(x => x.Description, dto.Description)
                    .SetProperty(x => x.Price, dto.Price)
                    .SetProperty(x => x.AuthorId, dto.AuthorId));
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Courses
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
        public async Task<List<CourseDto>> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    AuthorId = c.AuthorId,
 
                })
                .ToListAsync();
        }

    }
}
