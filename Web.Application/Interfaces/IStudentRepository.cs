using Web.Application.DTOs;

namespace Web.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task AddAsync(CreateStudentDto student);
        Task UpdateAsync(CreateStudentDto student);
        Task DeleteAsync(int id);
        Task<List<StudentDto>> GetByPageAsync(int page, int pageSize);
    }
}
