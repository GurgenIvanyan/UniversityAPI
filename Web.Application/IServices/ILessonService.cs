using Web.Core.Models;

namespace Web.Application.Interfaces
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonEntity>> GetAllAsync();
        Task<LessonEntity?> GetByIdAsync(int id);
        Task<LessonEntity> AddAsync(LessonEntity lesson);
        Task<LessonEntity> UpdateAsync(LessonEntity lesson);
        Task<bool> DeleteAsync(int id);
    }
}
