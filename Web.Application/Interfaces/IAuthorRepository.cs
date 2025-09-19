using Web.Application.DTOs;

namespace Web.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task AddAsync(CreateAuthorDto author);
        Task UpdateAsync(CreateAuthorDto author);
        Task DeleteAsync(int id);
        Task<List<AuthorDto>> GetByPageAsync(int page, int pageSize);
    }
}
