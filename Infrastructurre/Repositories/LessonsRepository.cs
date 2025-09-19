using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Application.DTOs;
using Web.Application.Interfaces;
using Web.Core.Models;

namespace Web.Infrastructure.Repositories
{
    public class LessonEfRepository : ILessonRepository
    {
        private readonly WebDbContext _dbContext;

        public LessonEfRepository(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(CreateLessonDto dto)
        {
            var course = await _dbContext.Courses.FindAsync(dto.CourseId);
            if (course == null)
            {
                course = new CourseEntity
                {
                    Id = dto.CourseId,
                    Title = dto.CourseTitle ?? "Default Title",
                    Description = "Auto-created course",
                    Price = 0
                };
                await _dbContext.Courses.AddAsync(course);
                await _dbContext.SaveChangesAsync();
            }

            var lesson = new LessonEntity
            {
                Title = dto.Title,
                Description = dto.Description,
                LessonText = dto.LessonText,
                CourseId = dto.CourseId
            };

            await _dbContext.Lessons.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LessonDto>> GetAllAsync()
        {
            return await _dbContext.Lessons
                .AsNoTracking()
                .Select(l => new LessonDto
                {
                    Id = l.Id,
                    Title = l.Title,
                    Description = l.Description,
                    LessonText = l.LessonText,
                    CourseId = l.CourseId
                })
                .ToListAsync();
        }

        public async Task<LessonDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Lessons
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new LessonDto
                {
                    Id = l.Id,
                    Title = l.Title,
                    Description = l.Description,
                    LessonText = l.LessonText,
                    CourseId = l.CourseId
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(CreateLessonDto dto)
        {
            await _dbContext.Lessons
                .ExecuteUpdateAsync(l => l
                    .SetProperty(x => x.Title, dto.Title)
                    .SetProperty(x => x.Description, dto.Description)
                    .SetProperty(x => x.LessonText, dto.LessonText)
                    .SetProperty(x => x.CourseId, dto.CourseId));
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Lessons
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<LessonDto>> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Lessons
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LessonDto
                {
                    Id = l.Id,
                    Title = l.Title,
                    Description = l.Description,
                    LessonText = l.LessonText,
                    CourseId = l.CourseId
                })
                .ToListAsync();
        }
    }
}
