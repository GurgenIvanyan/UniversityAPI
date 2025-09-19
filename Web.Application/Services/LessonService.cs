using Web.Application.DTOs;
using Web.Application.Interfaces;

namespace Web.Application.Services
{
    public class LessonService
    {
        private readonly ILessonRepository _repository;

        public LessonService(ILessonRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LessonDto>> GetAllAsync() => _repository.GetAllAsync();
        public Task<LessonDto?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(CreateLessonDto lesson) => _repository.AddAsync(lesson);
        public Task UpdateAsync(CreateLessonDto lesson) => _repository.UpdateAsync(lesson);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        public Task<List<LessonDto>> GetByPageAsync(int page, int pageSize) => _repository.GetByPageAsync(page, pageSize);
    }
}
