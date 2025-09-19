using Web.Application.DTOs;
using Web.Core.Models;

namespace Web.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task<AuthorDto> AddAsync(AuthorEntity author);
        Task<AuthorDto> UpdateAsync(AuthorEntity author);
        Task<bool> DeleteAsync(int id);
    }
}
