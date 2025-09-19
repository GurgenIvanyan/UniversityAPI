using Web.Application.DTOs;
using Web.Application.Interfaces;

namespace Web.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<List<CourseDto>> GetAllCoursesAsync() => _courseRepository.GetAllAsync();

        public Task<CourseDto?> GetCourseByIdAsync(int id) => _courseRepository.GetByIdAsync(id);

        public Task AddCourseAsync(CreateCourseDto course) => _courseRepository.AddAsync(course);

        public Task UpdateCourseAsync(CreateCourseDto course) => _courseRepository.UpdateAsync(course);

        public Task DeleteCourseAsync(int id) => _courseRepository.DeleteAsync(id);
    }
}
