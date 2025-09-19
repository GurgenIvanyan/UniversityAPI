using Web.Application.DTOs;
using Web.Application.Interfaces;

namespace Web.Application.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<List<StudentDto>> GetAllAsync() => _studentRepository.GetAllAsync();

        public Task<StudentDto?> GetByIdAsync(int id) => _studentRepository.GetByIdAsync(id);

        public Task AddAsync(CreateStudentDto student) => _studentRepository.AddAsync(student);

        public Task UpdateAsync(CreateStudentDto student) => _studentRepository.UpdateAsync(student);

        public Task DeleteAsync(int id) => _studentRepository.DeleteAsync(id);
    }
}
