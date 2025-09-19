using Web.Core.Models;

namespace Web.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentEntity>> GetAllAsync();
        Task<StudentEntity?> GetByIdAsync(int id);
        Task<StudentEntity> AddAsync(StudentEntity student);
        Task<StudentEntity> UpdateAsync(StudentEntity student);
        Task<bool> DeleteAsync(int id);
    }
}
