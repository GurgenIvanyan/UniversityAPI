using Web.Application.DTOs;
using Web.Application.Interfaces;

namespace Web.Application.Services
{
    public class AuthorService  
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<List<AuthorDto>> GetAllAsync() =>
            _authorRepository.GetAllAsync();

        public Task<AuthorDto?> GetByIdAsync(int id) =>
            _authorRepository.GetByIdAsync(id);

        public Task AddAsync(CreateAuthorDto author) =>
            _authorRepository.AddAsync(author);

        public Task UpdateAsync(CreateAuthorDto author) =>
            _authorRepository.UpdateAsync(author);

        public Task DeleteAsync(int id) =>
            _authorRepository.DeleteAsync(id);

    }
}
