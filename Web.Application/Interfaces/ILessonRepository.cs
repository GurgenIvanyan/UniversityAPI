using Web.Application.DTOs;

namespace Web.Application.Interfaces
{
    public interface ILessonRepository
    {
        Task<List<LessonDto>> GetAllAsync();
        Task<LessonDto?> GetByIdAsync(int id);
        Task AddAsync(CreateLessonDto lesson);
        Task UpdateAsync(CreateLessonDto lesson);
        Task DeleteAsync(int id);
        Task<List<LessonDto>> GetByPageAsync(int page, int pageSize);
    }
}
