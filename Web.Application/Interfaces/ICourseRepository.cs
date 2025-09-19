using Web.Application.DTOs;

namespace Web.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(int id);
        Task AddAsync(CreateCourseDto course);
        Task UpdateAsync(CreateCourseDto course);
        Task DeleteAsync(int id);
        Task<List<CourseDto>> GetByPageAsync(int page, int pageSize);
    }
}
