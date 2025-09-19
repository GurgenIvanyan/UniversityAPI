using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Application.DTOs;
using Web.Application.Interfaces;
using Web.Core.Models;

namespace Web.Infrastructure.Repositories
{
    public class AuthorEfRepository : IAuthorRepository
    {
        private readonly WebDbContext _dbContext;

        public AuthorEfRepository(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AuthorDto>> GetAllAsync()
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    UserName = a.UserName,
                    CourseId = a.CourseId
                })
                .ToListAsync();
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    UserName = a.UserName,
                    CourseId = a.CourseId
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(CreateAuthorDto dto)
        {
            var author = new AuthorEntity
            {
                UserName = dto.UserName,
                CourseId = dto.CourseId
            };

            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(CreateAuthorDto dto)
        {
            await _dbContext.Authors
                .ExecuteUpdateAsync(a => a
                    .SetProperty(x => x.UserName, dto.UserName)
                    .SetProperty(x => x.CourseId, dto.CourseId));

        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<AuthorDto>> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    UserName = a.UserName,
                    CourseId = a.CourseId
                })
                .ToListAsync();
        }
    }
}
