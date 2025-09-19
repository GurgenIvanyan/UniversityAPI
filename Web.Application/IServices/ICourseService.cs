using Web.Core.Models;

namespace Web.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseEntity>> GetAllAsync();
        Task<CourseEntity?> GetByIdAsync(int id);
        Task<CourseEntity> AddAsync(CourseEntity course);
        Task<CourseEntity> UpdateAsync(CourseEntity course);
        Task<bool> DeleteAsync(int id);
    }
}
